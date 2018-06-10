using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.GUI;

namespace Checkers.Logic
{
    public class Game1
    {
        private Board m_Board;
        private IPlayer m_Player1;
        private IPlayer m_Player2;
        private IPlayer m_CurrentPlayer;

        


        public Game1(IPlayer i_Player1, IPlayer i_Player2, int i_BoardSize)
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_CurrentPlayer = i_Player1;
            initializeBoard(i_BoardSize);
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
                        IPiece piece = new PieceO();
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
                        IPiece piece = new PieceX();
                        m_Board.GetCell(i, j).Piece = piece;
                        m_Player1.AddPiece(piece);
                    }
                }
            }
        }

        public void StartGame()
        {
            GameUI gameUi = new GameUI(this);
            gameUi.ShowDialog();
        }

        public bool isValidSource(Cell i_SourceCell)
        {
            return m_CurrentPlayer.DoesContain(i_SourceCell.Piece);
        }

        public bool isValidTarget(Cell i_TargetCell, Cell i_OptionalSourceCell)
        {
            return isValidMove(i_OptionalSourceCell, i_TargetCell);
        }

        public bool isValidMove(Cell i_Source, Cell i_Target)
        {
            if (!i_Source.Piece.isKing())
            {

            }
            else
            {

            }
        }

        private bool isManJump()
        {
            return 
        }
    }
}
