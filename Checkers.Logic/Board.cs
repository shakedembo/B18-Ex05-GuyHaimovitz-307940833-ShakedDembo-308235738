using System;

namespace Checkers.Logic
{
    public class Board
    {
        private Cell[,] m_Board;


        public Board(int i_BoardSize)
        {
            m_Board = new Cell [i_BoardSize, i_BoardSize];

            for (int i = 0; i < i_BoardSize; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    m_Board[i, j] = new Cell(new Tuple<int, int>(i, j));
                }
            }
        }

        public int GetSize()
        {
            return m_Board.GetLength(0);
        }

        public Cell GetCell(int i, int j)
        {
            if (isValidCoordinate(i, j))
            {
                return m_Board[i, j];
            }
            else
            {
                return null;
            }
        }

        private bool isValidCoordinate(int row, int col)
        {
            return (row >= 0 && row < GetSize()) && (col >= 0 && col < GetSize());
        }

        /**
         * Assumes valid coordinate
         */
        public bool IsOccupied(int i, int j)
        {
            return GetCell(i, j).Piece != null;
        }

        /**
         * Assumes valid Cell
         */
        public bool IsOccupied(Cell i_Cell)
        {
            return i_Cell.Piece != null;
        }

        internal Cell[,] BoardCells
        {
            get { return m_Board; }
        }
    }
}
