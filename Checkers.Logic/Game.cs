using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers.Logic
{
    public class Game
    {
        private Board m_Board;
        private IPlayer m_Player1;
        private IPlayer m_Player2;
        private IPlayer m_CurrentPlayer;

        public delegate void endGameHandler();

        public event endGameHandler GameEnded = () => { };

        public delegate void moveHaveBeenMadeHandler();

        public event moveHaveBeenMadeHandler MoveHaveBeenMade = () => { };
        

        public Game(IPlayer i_Player1, IPlayer i_Player2, int i_BoardSize)
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_CurrentPlayer = i_Player1;
            initializeBoard(i_BoardSize);
        }

        public Tuple<IPlayer, int> calculateScore()
        {
            int player1Score = 0;
            int player2Score = 0;
            foreach (var piece in m_Player1.Pieces)
            {
                player1Score += piece.isKing() ? 4 : 1;
            }

            foreach (var piece in m_Player2.Pieces)
            {
                player2Score += piece.isKing() ? 4 : 1;
            }

            IPlayer winner = player1Score > player2Score ? m_Player1 : m_Player2;
            int winnerScore = Math.Abs(player1Score - player2Score);
            return new Tuple<IPlayer, int>(winner, winnerScore);
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

        private bool DoesGameEnded()
        {
            bool result;
            foreach (var piece in CurrentPlayer.Pieces)
            {
                //has something to do?
                if (checkPossibleMoves(this, CurrentPlayer.Color).Count == 0)
                {
                    result = false;
                    break;
                }
            }
            result = m_Player1.Pieces.Count == 0 || m_Player2.Pieces.Count == 0;

            return result;
        }

        internal static List<Move> checkPossibleMoves(Game i_Game, PlayerColor i_Color)
        {
            List<Move> possibleMoves = new List<Move>();
            Move move;

            foreach (Cell source in i_Game.Board.BoardCells)
            {
                if (source.Piece is PieceO)
                {
                    foreach (Cell dest in i_Game.Board.BoardCells)
                    {
                        move = new Move(i_Game, source, dest);
                        if (move.Result)
                        {
                            possibleMoves.Add(move);
                        }
                    }
                }
            }
            return possibleMoves;
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

                MoveHaveBeenMade.Invoke();
                
                //is game ended?
                if (DoesGameEnded())
                {
                    GameEnded.Invoke();
                    return;
                }

                //another turn?
                if (move.IsJump)
                {
                    if (isAnotherTurn(move))
                    {
                        if (m_CurrentPlayer is PcPlayer)
                        {
                            (m_CurrentPlayer as PcPlayer).getNextMoveFromPc(this, move);
                            return;
                        }
                        else
                        {
                            //next move from human
                            return;
                        }
                    }
                }
                switchCurrentTurn();
            }
        }

        

        private bool isAnotherTurn(Move i_Move)
        {
            return i_Move.hasToEat(i_Move.Destination.Piece);
        }

        private void switchCurrentTurn()
        {
            m_CurrentPlayer = CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;

            if (m_CurrentPlayer is PcPlayer)
            {
                Move PCmove = (m_CurrentPlayer as PcPlayer).GetMove(this);
                MakeMove(PCmove.Source, PCmove.Destination);
            }

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
