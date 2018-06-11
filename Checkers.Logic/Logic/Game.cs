using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers.GUI;

namespace Checkers.Logic
{
    public class Game
    {
        private Board m_Board;
        private IPlayer m_Player1;
        private IPlayer m_Player2;
        private IPlayer m_CurrentPlayer;

        private static IPlayer m_Winner;
        private bool m_IsTie;
        private bool m_GameEnded;


        public Game(IPlayer i_Player1, IPlayer i_Player2, int i_BoardSize)
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_CurrentPlayer = i_Player1;
            initializeBoard(i_BoardSize);
        }

        private void endGame()
        {
            calculateScore();
            m_GameEnded = true;

        }

        public void calculateScore()
        {
            int player1Score = 0;
            int player2Score = 0;
            foreach (var piece in m_Player1.Pieces)
            {
                player1Score += piece.isKing() ? 4 : 1;
            }

            m_Winner = player1Score > player2Score ? m_Player1 : m_Player2;
            m_Winner = player1Score == player2Score ? null : m_Winner;

            int winnerScore = Math.Abs(player1Score - player2Score);
            m_Winner.PlayerScore += winnerScore;
            m_IsTie = winnerScore == 0;
        }

        private void initializeBoard(int i_BoardSize)
        {
            m_Board = new Board(i_BoardSize);

            for (int i = 0; i < (i_BoardSize / 2) - 1; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        IPiece piece = new PieceO(new Tuple<int, int>(i, j));
                        m_Board.GetCell(i, j).Piece = piece;
                        m_Player2.AddPiece(piece);
                    }
                }
            }

            for (int i = (i_BoardSize / 2) + 1; i < i_BoardSize; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        IPiece piece = new PieceX(new Tuple<int, int>(i, j));
                        m_Board.GetCell(i, j).Piece = piece;
                        m_Player1.AddPiece(piece);
                    }
                }
            }
        }

        public bool StartGame()
        {
            GameUI gameUi = new GameUI(this);
            gameUi.ShowDialog();
            
        }

        private bool DoesGameEnded()
        {
            return m_Player1.Pieces.Count == 0 || m_Player2.Pieces.Count == 0;
        }

        public void MakeMove(Cell i_Source, Cell i_Destination)
        {
            Move move = new Move(this, i_Source, i_Destination);
            if (move.Result)
            {
                i_Source.Piece.Position = new Tuple<int, int>(i_Destination.Row, i_Destination.Col);
                i_Destination.Piece = i_Source.Piece;
                i_Source.Piece = null;

                if (move.IsJump)
                {
                    int inBetweenCol = i_Destination.Col > i_Source.Col ? i_Source.Col + 1 : i_Source.Col - 1;
                    int inBetweenRow = i_Destination.Row > i_Source.Row ? i_Source.Row + 1 : i_Source.Row - 1;
                    IPiece pieceToRemove = m_Board.GetCell(inBetweenRow, inBetweenCol).Piece;

                    if (m_Player1.RemovePiece(pieceToRemove))
                    {
                        m_Board.GetCell(inBetweenRow, inBetweenCol).Piece = null;
                    }
                    else
                    {
                        m_Player2.RemovePiece(pieceToRemove);
                        m_Board.GetCell(inBetweenRow, inBetweenCol).Piece = null;
                    }


                }
                //isKing?
                CheckToMakeKing(i_Destination.Piece);
                //another turn?
                if (move.IsJump)
                {
                    if (IsAnotherTurn(move))
                    {
                        return;
                    }
                }
                //is game ended?
                if (DoesGameEnded())
                {
                    
                }
                switchCurrentTurn();
            }
        }

        private bool IsAnotherTurn(Move i_Move)
        {
            return i_Move.hasToEat(i_Move.Destination.Piece);
        }

        private void switchCurrentTurn()
        {
            m_CurrentPlayer = CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;
        }

        private void CheckToMakeKing(IPiece i_Piece)
        {
            if (isKingRow(i_Piece))
            {
                i_Piece.KingMe();
            }
        }

        private bool isKingRow(IPiece i_Piece)
        {
            return (i_Piece is PieceO) ? i_Piece.Row == m_Board.GetSize() - 1 : i_Piece.Row == 0;
        }

        public bool isValidSource(Cell i_SourceCell)
        {
            return m_CurrentPlayer.DoesContain(i_SourceCell.Piece);
        }

        public bool isValidTarget(Cell i_DestinationCell, Cell i_OptionalSourceCell)
        {
            Move move = new Move(this, i_OptionalSourceCell, i_DestinationCell);
            return move.Result;
        }

     
        public IPlayer CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        public Board Board
        {
            get { return m_Board; }
        }
    }
}
