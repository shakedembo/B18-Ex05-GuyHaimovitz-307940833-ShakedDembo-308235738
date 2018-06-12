using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Logic
{
    class Move
    {
        private Game m_Game;
        private Cell m_Source;
        private Cell m_Destination;

        private bool m_Result;
        private bool m_IsJump;

        public Move(Game i_Game, Cell i_Source, Cell i_Destination)
        {
            m_Source = i_Source;
            m_Destination = i_Destination;
            m_Game = i_Game;
            m_Result = isValidMove(); //sets isJump as well

        }

        private bool isValidMove()
        {
            bool Jump = m_Source.Piece.isKing() ? isKingValidJump() : isManValidJump();
            m_IsJump = Jump;
            
            return (m_Source.Piece.isKing()
                ? Jump || isKingValidMove()
                : Jump || isManValidMove());
        }

        private bool isKingValidJump()
        {
            int colDifference = m_Destination.Col - m_Source.Col;
            return ((m_Destination.Row == m_Source.Row + 2) || (m_Destination.Row == m_Source.Row - 2)) && 
                   (colDifference == 2 || colDifference == -2) && (isValidJumpForKing());
        }

        private bool isKingValidMove()
        {
            int colDifference = m_Destination.Col - m_Source.Col;
            return ((m_Destination.Row == m_Source.Row + 1)
                    || (m_Destination.Row == m_Source.Row - 1))
                   && (colDifference == -1 || colDifference == 1) && (!hasToEat())
                   && (!m_Game.Board.IsOccupied(m_Destination));
        }

        private bool isManValidJump()
        {
            int colDifference = m_Destination.Col - m_Source.Col;
            return (((m_Destination.Row == m_Source.Row - 2) && (m_Game.CurrentPlayer.Color == PlayerColor.Black)) 
                    || ((m_Destination.Row == m_Source.Row + 2) &&(m_Game.CurrentPlayer.Color == PlayerColor.White))) 
                   && (colDifference == -2 || colDifference == 2) && (isValidJumpForMan());
        }

        private bool isManValidMove()
        {
            int colDifference = m_Destination.Col - m_Source.Col;
            return ((m_Destination.Row == m_Source.Row - 1) && (m_Game.CurrentPlayer.Color == PlayerColor.Black)
                    || (m_Destination.Row == m_Source.Row + 1) && (m_Game.CurrentPlayer.Color == PlayerColor.White))
                   && (colDifference == -1 || colDifference == 1) && (!hasToEat()) && (!m_Game.Board.IsOccupied(m_Destination));
        }

        private bool isValidJumpForKing()
        {
            return m_Game.CurrentPlayer.Color == PlayerColor.Black ? 
                isValidKingBlackJump() : isValidKingWhiteJump();
        }

        private bool isValidKingWhiteJump()
        {
            int inBetweenCol = m_Destination.Col > m_Source.Col ? m_Source.Col + 1 : m_Source.Col - 1;
            int inBetweenRow = m_Destination.Row > m_Source.Row ? m_Source.Row + 1 : m_Source.Row - 1;
            return (!m_Game.Board.IsOccupied(m_Destination) &&
                    m_Game.Board.GetCell(inBetweenRow, inBetweenCol).Piece is PieceX);
        }

        private bool isValidKingBlackJump()
        {
            int inBetweenCol = m_Destination.Col > m_Source.Col ? m_Source.Col + 1 : m_Source.Col - 1;
            int inBetweenRow = m_Destination.Row > m_Source.Row ? m_Source.Row + 1 : m_Source.Row - 1;
            return (!m_Game.Board.IsOccupied(m_Destination) &&
                   m_Game.Board.GetCell(inBetweenRow, inBetweenCol).Piece is PieceO);
        }

        private bool isValidJumpForMan()
        {
            bool result;
            if (m_Game.CurrentPlayer.Color == PlayerColor.Black)
            {
                result = isValidManBlackJump();
            }
            else
            {
                result = isValidManWhiteJump();
            }

            return result;
        }
        /**
         * Checks only if the pieces in between and in dest are valid
         */
        private bool isValidManWhiteJump()
        {
            int inBetweenCol = m_Destination.Col > m_Source.Col ? m_Source.Col + 1 : m_Source.Col - 1;
            return !m_Game.Board.IsOccupied(m_Destination) && m_Game.Board.GetCell(m_Source.Row + 1, inBetweenCol).Piece is PieceX;
        }

        /**
         * Checks only if the pieces in between and in dest are valid
         */
        private bool isValidManBlackJump()
        {
            int inBetweenCol = m_Destination.Col > m_Source.Col ? m_Source.Col + 1 : m_Source.Col - 1;
            return !m_Game.Board.IsOccupied(m_Destination) && (m_Game.Board.GetCell(m_Source.Row - 1, inBetweenCol).Piece is PieceO);
        }

        private bool hasToEat()
        {
            bool result = false;
            foreach (IPiece piece in m_Game.CurrentPlayer.Pieces)
            {
                if (hasToEat(piece))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        internal bool hasToEat(IPiece piece)
        {
            bool result = false;

            //Man
            if (!piece.isKing())
            {
                if (m_Game.CurrentPlayer.Color == PlayerColor.White)
                {
                    Cell cell1 = m_Game.Board.GetCell(piece.Row + 1, piece.Col + 1);
                    Cell cell2 = m_Game.Board.GetCell(piece.Row + 1, piece.Col - 1);

                    Cell cell3 = m_Game.Board.GetCell(piece.Row + 2, piece.Col + 2);
                    Cell cell4 = m_Game.Board.GetCell(piece.Row + 2, piece.Col - 2);

                    if (cell1 != null && cell3 != null)
                    {
                        result |= (cell1.Piece is PieceX && !m_Game.Board.IsOccupied(cell3));
                    }

                    if (cell2 != null && cell4 != null)
                    {
                        result |= (cell2.Piece is PieceX && !m_Game.Board.IsOccupied(cell4));
                    }
                }
                //Player is White
                else
                {
                    Cell cell1 = m_Game.Board.GetCell(piece.Row - 1, piece.Col + 1);
                    Cell cell2 = m_Game.Board.GetCell(piece.Row - 1, piece.Col - 1);

                    Cell cell3 = m_Game.Board.GetCell(piece.Row - 2, piece.Col + 2);
                    Cell cell4 = m_Game.Board.GetCell(piece.Row - 2, piece.Col - 2);

                    if (cell1 != null && cell3 != null)
                    {
                        result |= (cell1.Piece is PieceO && !m_Game.Board.IsOccupied(cell3));
                    }

                    if (cell2 != null && cell4 != null)
                    {
                        result |= (cell2.Piece is PieceO && !m_Game.Board.IsOccupied(cell4));
                    }
                }

            }
            //King
            else
            {
                Cell cell1 = m_Game.Board.GetCell(piece.Row + 1, piece.Col + 1);
                Cell cell2 = m_Game.Board.GetCell(piece.Row + 1, piece.Col - 1);
                Cell Upside1 = m_Game.Board.GetCell(piece.Row - 1, piece.Col + 1);
                Cell Upside2 = m_Game.Board.GetCell(piece.Row - 1, piece.Col + 1);


                Cell cell3 = m_Game.Board.GetCell(piece.Row + 2, piece.Col + 2);
                Cell cell4 = m_Game.Board.GetCell(piece.Row + 2, piece.Col - 2);
                Cell Upside3 = m_Game.Board.GetCell(piece.Row - 2, piece.Col + 2);
                Cell Upside4 = m_Game.Board.GetCell(piece.Row - 2, piece.Col + 2);

                if (m_Game.CurrentPlayer.Color == PlayerColor.White)
                {
                    if (cell1 != null && cell3 != null)
                    {
                        result |= (cell1.Piece is PieceX && !m_Game.Board.IsOccupied(cell3));
                    }

                    if (cell2 != null && cell4 != null)
                    {
                        result |= (cell2.Piece is PieceX && !m_Game.Board.IsOccupied(cell4));
                    }

                    if (Upside1 != null && Upside3 != null)
                    {
                        result |= (Upside1.Piece is PieceX && !m_Game.Board.IsOccupied(Upside3));
                    }

                    if (Upside2 != null && Upside4 != null)
                    {
                        result |= (Upside2.Piece is PieceX && !m_Game.Board.IsOccupied(Upside4));
                    }

                }
                //White
                else
                {
                    if (cell1 != null && cell3 != null)
                    {
                        result |= (cell1.Piece is PieceO && !m_Game.Board.IsOccupied(cell3));
                    }

                    if (cell2 != null && cell4 != null)
                    {
                        result |= (cell2.Piece is PieceO && !m_Game.Board.IsOccupied(cell4));
                    }

                    if (Upside1 != null && Upside3 != null)
                    {
                        result |= (Upside1.Piece is PieceO && !m_Game.Board.IsOccupied(Upside3));
                    }

                    if (Upside2 != null && Upside4 != null)
                    {
                        result |= (Upside2.Piece is PieceO && !m_Game.Board.IsOccupied(Upside4));
                    }
                }
            }
            return result;
        }

        public bool Result
        {
            get { return m_Result; }
        }
        public bool IsJump
        {
            get { return m_IsJump; }
        }

        public Cell Destination
        {
            get { return m_Destination; }
        }
        public Cell Source
        {
            get { return m_Source; }
        }


    }
}
