using System;
using System.Collections.Generic;

namespace Checkers
{
    class PcPlayer : Player
    {
        private string m_Name;
        private PlayerColor m_Color;
        private bool m_IsHuman;


        public PcPlayer(string i_Name, PlayerColor i_Color, bool i_IsHuman) : base(i_Name, i_Color, i_IsHuman)
        {
            this.m_Color = i_Color;
            this.m_Name = i_Name;
            this.m_IsHuman = i_IsHuman;
            this.m_PlayerCheckers = new List<Game.Coordinate>();
        }

        public Move GetMove(Board i_Board)
        {
            List<Move> possibleMoves = generatePossibleMoves(i_Board);
            Random rnd = new Random();
            int RandomIndex = rnd.Next(0, possibleMoves.Count - 1);


            return possibleMoves[RandomIndex];
        }

        private List<Move> generatePossibleMoves(Board i_Board)
        {
            List<Move> possibleMoves = new List<Move>();
            string moveString;
            Move move;
            foreach (Game.Coordinate checker in m_PlayerCheckers)
            {
                //Check valid regular moving options
                Game.Coordinate destinationRight = new Game.Coordinate(checker.Row + 1, checker.Col + 1);
                moveString = tranformToString(checker, destinationRight);
                move = new Move(i_Board, this);
                if (move.PcSuggestMove(moveString))
                {
                    possibleMoves.Add(move);
                }

                Game.Coordinate destinationLeft = new Game.Coordinate(checker.Row + 1, checker.Col - 1);
                moveString = tranformToString(checker, destinationLeft);
                move = new Move(i_Board, this);
                if (move.PcSuggestMove(moveString))
                {
                    possibleMoves.Add(move);
                }

                //King
                if (i_Board.GetCellContent(checker) == Cell.eCellState.U)
                {
                    Game.Coordinate destinationRightBack = new Game.Coordinate(checker.Row - 1, checker.Col + 1);
                    moveString = tranformToString(checker, destinationRightBack);
                    move = new Move(i_Board, this);
                    if (move.PcSuggestMove(moveString))
                    {
                        possibleMoves.Add(move);
                    }

                    Game.Coordinate destinationLeftBack = new Game.Coordinate(checker.Row - 1, checker.Col - 1);
                    moveString = tranformToString(checker, destinationLeftBack);
                    move = new Move(i_Board, this);
                    if (move.PcSuggestMove(moveString))
                    {
                        possibleMoves.Add(move);
                    }
                }

                //Check valid jumping options
                Game.Coordinate destinationRightJump = new Game.Coordinate(checker.Row + 2, checker.Col + 2);
                moveString = tranformToString(checker, destinationRightJump);
                move = new Move(i_Board, this);
                if (move.PcSuggestMove(moveString))
                {
                    possibleMoves.Add(move);
                }

                Game.Coordinate destinationLeftJump = new Game.Coordinate(checker.Row + 2, checker.Col - 2);
                moveString = tranformToString(checker, destinationLeftJump);
                move = new Move(i_Board, this);
                if (move.PcSuggestMove(moveString))
                {
                    possibleMoves.Add(move);
                }

                //King
                if (i_Board.GetCellContent(checker) == Cell.eCellState.U)
                {
                    Game.Coordinate destinationRightBackJump = new Game.Coordinate(checker.Row - 2, checker.Col + 2);
                    moveString = tranformToString(checker, destinationRightBackJump);
                    move = new Move(i_Board, this);
                    if (move.PcSuggestMove(moveString))
                    {
                        possibleMoves.Add(move);
                    }

                    Game.Coordinate destinationLeftBackJump = new Game.Coordinate(checker.Row - 2, checker.Col - 2);
                    moveString = tranformToString(checker, destinationLeftBackJump);
                    move = new Move(i_Board, this);
                    if (move.PcSuggestMove(moveString))
                    {
                        possibleMoves.Add(move);
                    }
                }
            }

            return possibleMoves;
        }

        private string tranformToString(Game.Coordinate i_Checker1, Game.Coordinate i_Checker2)
        {
            char col1 = (char) (i_Checker1.Col + 'A');
            char row1 = (char) (i_Checker1.Row + 'a');
            char col2 = (char) (i_Checker2.Col + 'A');
            char row2 = (char) (i_Checker2.Row + 'a');

            return col1.ToString() + row1.ToString() + '>' + col2.ToString() + row2.ToString();
        }
    }
}
