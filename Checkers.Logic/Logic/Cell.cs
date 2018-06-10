using System;

namespace Checkers
{
    public class Cell
    {
        public enum eCellState
        {
            X,
            O,
            Empty,
            K,
            U
        }

        private eCellState m_Content = eCellState.Empty;

        public eCellState Content 
        {
            get { return m_Content; }
            set { m_Content = value; }
        }

        internal void printCellContent()
        {
            if (m_Content == eCellState.X)
            {
                Console.Write("X");
            }
            else if (m_Content == eCellState.O)
            {
                Console.Write("O");
            }
            else if (m_Content == eCellState.Empty)
            {
                Console.Write(" ");
            }
            else if (m_Content == eCellState.K)
            {
                Console.Write("K");
            }
            else
            {
                Console.Write("U");
            }
        }
    }
}
