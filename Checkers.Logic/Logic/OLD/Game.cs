using System;
using System.Threading;
using Checkers.Logic.GUI;

namespace Checkers
{
    public class Game
    {
        private Board m_Board;
        private IPlayer m_Player1;
        private Player m_Player2;

        private static int moveCounter = 0;



        public Game(Player i_Player1, Player i_Player2, int i_BoardSize, int numberOfPlayers)
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            initializeBoard(i_BoardSize);
        }

        public Tuple<int, Player> StartGame()
        {
            printGame();

            while (true)
            {
                Move move;

                if (moveCounter % 2 == 0)
                {
                    move = new Move(m_Board, m_Player1);

                }
                else
                {
                    if (m_Player2.IsHuman)
                    {
                        //get source (click)
                        move = new Move(m_Board, m_Player2);
                    }
                    else
                    {
                        PcPlayer_Old pc = (PcPlayer_Old) m_Player2;
                        move = pc.GetMove(m_Board);
                    }
                }

                if (move.ToQuit)
                {
                    Tuple<int, Player> winning = CheckWinner();
                    if (winning.Item2 != move.Player)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }

                makeMove(move);
                printAfterMove(move);
                moveCounter++;
            }

            return CheckWinner();
        }

        private void makeMove(Move move)
        {
            if (move.ToQuit)
            {

            }
            else if (move.IsJump)
            {
                Cell.eCellState
                    sourceCellContent = m_Board.GetCellContent(move.Source); // get the source cell content/type
                m_Board.SetCell(Cell.eCellState.Empty, move.Source); //empty source cell
                m_Board.SetCell(sourceCellContent, move.Destination); //change dest to the type of source cell
                move.Player.m_PlayerCheckers.Remove(move.Source); //remove the source location from the list
                move.Player.m_PlayerCheckers.Add(move.Destination); //add the dest location to the 
                m_Board.SetCell(Cell.eCellState.Empty, move.ToEat);
                Player opponent = m_Player1;
                if (move.Player == m_Player1)
                {
                    opponent = m_Player2;
                }

                opponent.m_PlayerCheckers.Remove(move.ToEat);


                Move nextMove = move;



                while (nextMove.hasToEat(nextMove.Destination))
                {
                    printAfterMove(nextMove);
                    nextMove = new Move(m_Board, move.Player);
                    if (nextMove.IsJump && nextMove.Source.Equals(move.Destination))
                    {
                        makeMove(nextMove);
                        move = nextMove;
                    }
                }
            }
            else
            {
                Cell.eCellState
                    sourceCellContent = m_Board.GetCellContent(move.Source); // get the source cell content/type
                m_Board.SetCell(Cell.eCellState.Empty, move.Source); //empty source cell
                m_Board.SetCell(sourceCellContent, move.Destination); //change dest to the type of source cell
                move.Player.m_PlayerCheckers.Remove(move.Source); //remove the source location from the list
                move.Player.m_PlayerCheckers.Add(move.Destination); //add the dest location to the list


            }

            if (ifKingme(move.Destination, move.Player.Color))
            {
                if (m_Board.GetCellContent(move.Destination) == Cell.eCellState.X)
                {
                    m_Board.SetCell(Cell.eCellState.K, move.Destination);
                }
                else if (m_Board.GetCellContent(move.Destination) == Cell.eCellState.O)
                {
                    m_Board.SetCell(Cell.eCellState.U, move.Destination);
                }
            }



        }

        private bool ifKingme(Coordinate moveDestination, Player.PlayerColor color)
        {
            return (color == Player.PlayerColor.White && moveDestination.Row == m_Board.GetSize() - 1) ||
                   (color == Player.PlayerColor.Black && moveDestination.Row == 0);
        }


        public void printAfterMove(Move i_LastMove)
        {
            printGame();
            string toPrint = getSymbole(i_LastMove.Player.Color);
            Console.WriteLine(i_LastMove.Player.Name + "'s move was " + toPrint + ": " + i_LastMove.Input);
        }

        public void printGame()
        {
            Console.Clear();
            this.m_Board.Print();
        }

        private string getSymbole(Player.PlayerColor i_Color)
        {
            string toReturn;
            if (i_Color == Player.PlayerColor.Black)
            {
                toReturn = "(X)";
            }
            else
            {
                toReturn = "(O)";
            }

            return toReturn;
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
                        m_Board.SetCell(Cell.eCellState.O, new Coordinate(i, j));
                        m_Player2.m_PlayerCheckers.Add(new Coordinate(i, j));
                    }
                }
            }

            for (int i = (i_BoardSize / 2) + 1; i < i_BoardSize; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        m_Board.SetCell(Cell.eCellState.X, new Coordinate(i, j));
                        m_Player1.m_PlayerCheckers.Add(new Coordinate(i, j));
                    }
                }
            }
        }

        private Tuple<int, Player> CheckWinner()
        {
            int PlayerOneScore = calcScore(m_Player1);
            int PlayerTwoScore = calcScore(m_Player2);
            int FinalScore = Math.Abs(PlayerOneScore - PlayerTwoScore);
            Player winner = m_Player1;
            if (PlayerTwoScore > PlayerOneScore)
            {
                winner = m_Player2;
            }

            //Chicken Dinner
            return new Tuple<int, Player>(FinalScore, winner);
        }

        private int calcScore(Player i_Player)
        {
            int sum = 0;
            foreach (Coordinate checker in i_Player.m_PlayerCheckers)
            {
                if (m_Board.GetCellContent(checker) == Cell.eCellState.X ||
                    m_Board.GetCellContent(checker) == Cell.eCellState.O)
                {
                    sum++;
                }
                else
                {
                    sum += 4;
                }
            }

            return sum;
        }

        public int GetBoardSize()
        {
            return this.m_Board.GetSize();
        }

        public struct Coordinate
        {
            private int m_RowNumber;
            private int m_ColNumber;

            public Coordinate(int i_Row, int i_Col)
            {
                m_ColNumber = i_Col;
                m_RowNumber = i_Row;
            }

            public Coordinate(char i_Row, char i_Col)
            {
                int row = (i_Row - 'a');
                int col = (i_Col - 'A');
                m_ColNumber = col;
                m_RowNumber = row;
            }

            public int Row
            {
                get { return this.m_RowNumber; }
                set { this.m_RowNumber = value; }
            }

            public int Col
            {
                get { return this.m_ColNumber; }
                set { this.m_ColNumber = value; }
            }


        }

        public Cell GetCell(int i, int j)
        {
            return m_Board.GetCell(i, j);
        }

        public void InitiateMove(Coordinate i_SourceCoordinate)
        {
            Move move;

            if (moveCounter % 2 == 0)
            {
                move = new Move(m_Board, m_Player1, i_SourceCoordinate);

            }
            else
            {
                if (m_Player2.IsHuman)
                {
                    //get source (click)
                    move = new Move(m_Board, m_Player2, i_SourceCoordinate);
                }
                else
                {
                    PcPlayer_Old pc = (PcPlayer_Old) m_Player2;
                    move = pc.GetMove(m_Board);
                }
            }
        }

        public bool isValidSource(Coordinate i_SourceCoordinate)
        {
            Move move;

            if (moveCounter % 2 == 0)
            {
                move = new Move(m_Board, m_Player1, i_SourceCoordinate);

            }
            else
            {
                move = new Move(m_Board, m_Player2, i_SourceCoordinate);
            }

            
        }
    }
}
