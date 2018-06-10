using System;

namespace Checkers
{
    class Board
    {
        private Cell[,] m_Board;


        public Board(int i_BoardSize)
        {
            m_Board = new Cell [i_BoardSize, i_BoardSize];

            for (int i = 0; i < i_BoardSize; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    m_Board[i, j] = new Cell();
                }
            }
        }

        public void Print()
        {
            int boardSize = m_Board.GetLength(0);

            for (char c = 'A'; c < 'A' + boardSize; c++)
            {
                Console.Write("   " + c);
            }
  
            printSeperator();

            for(int rowNumber = 0; rowNumber < boardSize; rowNumber++)
            {
                char rowChar = (char) ('a' + rowNumber);
                Console.Write(rowChar + "|");
                
                for (int colNumber = 0; colNumber < boardSize; colNumber++)
                {
                    Console.Write(" ");
                    m_Board[rowNumber, colNumber].printCellContent();
                    Console.Write(" |");
                }
                printSeperator();
            }
        }

        private void printSeperator()
        {
            int boardSize = m_Board.GetLength(0);
            Console.WriteLine();
            Console.Write(" ");
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("====");
            }
            Console.WriteLine("=");
        }

        public void SetCell(Cell.eCellState iState, Game.Coordinate i_Location)
        {
            m_Board[i_Location.Row, i_Location.Col].Content = iState;
        }

        public int GetSize()
        {
            return m_Board.GetLength(0);
        }

        public Cell.eCellState GetCellContent(Game.Coordinate i_Coordinate)
        {
            return m_Board[i_Coordinate.Row, i_Coordinate.Col].Content;
        }

        public bool IsOccupied(Cell cell)
        {
            return cell.Content != Cell.eCellState.Empty;
        }
    }
}
