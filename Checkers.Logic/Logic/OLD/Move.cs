using System;

namespace Checkers
{
    public class Move
    {
        private Board m_CurrentBoard;
        private bool m_IsValidMove;
        private Game.Coordinate m_Source;
        private bool m_IsMan = true;
        private bool m_IsJump;
        private bool m_ToQuit;
        private Game.Coordinate m_Destination;
        private Game.Coordinate m_ToEat;
        private Player m_Player;
        private string m_Input;


        public Move(Board i_CurrentBoard, Player i_Player, Game.Coordinate i_Source)
        {
            m_Source = i_Source;

            if (i_Player.IsHuman)
            {
                InitializeMove(i_CurrentBoard, i_Player);
            }
            else
            {
                InitializePcMove(i_CurrentBoard, i_Player);
            }
        }


        public Move(Board i_CurrentBoard, Player i_Player)
        {
            if (i_Player.IsHuman)
            {
                InitializeMove(i_CurrentBoard, i_Player);
            }
            else
            {
                InitializePcMove(i_CurrentBoard, i_Player);
            }
        }

        public void InitializeMove(Board i_CurrentBoard, Player i_Player)
        {
            this.m_Player = i_Player;
            m_CurrentBoard = i_CurrentBoard;
            AskforMove();
        }

        internal void InitializePcMove(Board i_CurrentBoard, Player i_Player)
        {
            this.m_Player = i_Player;
            m_CurrentBoard = i_CurrentBoard;
        }

        private void AskforMove()
        {
            string move = "";
            while (!m_IsValidMove)
            {
                Console.Write(m_Player.Name + " what is your next move? ");
                move = Console.ReadLine();
                isValidMove(move);
            }

            m_Input = move;

        }

        public bool PcSuggestMove(string move)
        {
            
            isValidMove(move);
            if (m_IsValidMove)
            {
                m_Input = move;
            }

            return m_IsValidMove;
        }

        private bool isLegalFormatMove(string i_Move)
        {
            bool result = true;
            if (!i_Move.Equals("Q"))
            {
                char[] move = i_Move.ToCharArray();
                if (move.Length != 5)
                {
                    result = false;
                }
                else
                {
                    result = (move[0] >= 'A') && (move[0] < ('A' + m_CurrentBoard.GetSize()));
                    result &= (move[1] >= 'a') && (move[1] < ('a' + m_CurrentBoard.GetSize()));
                    result &= move[2] == '>';
                    result &= (move[3] >= 'A') && (move[3] < ('A' + m_CurrentBoard.GetSize()));
                    result &= (move[4] >= 'a') && (move[4] < ('a' + m_CurrentBoard.GetSize()));
                }
            }

            return result;
        }


        private void setCoordinates(string i_Move)
        {
            char[] move = i_Move.ToCharArray();
            m_Source = new Game.Coordinate(move[1], move[0]);
            m_Destination = new Game.Coordinate(move[4], move[3]);
        }

        private void isValidMoveGUI()
        {
            
            Cell.eCellState sourceState = m_CurrentBoard.GetCellContent(m_Source);

            if (isValidSourceType(sourceState))
            {
                

                //wait for another click
                Cell.eCellState destinationState = m_CurrentBoard.GetCellContent(m_Destination);
                if () {
                    m_IsMan = sourceState == Cell.eCellState.O || sourceState == Cell.eCellState.X;
                    if (m_IsMan)
                    {
                        m_IsJump = isManJump();
                        if (m_IsJump)
                        {
                            m_IsValidMove = isValidJump();
                        }
                        else
                        {
                            if (!hasToEat())
                            {
                                if (isValidManMove())
                                {
                                    m_IsValidMove = true;
                                }
                                else
                                {
                                    if (m_Player.IsHuman)
                                    {
                                        Console.WriteLine("Invalid move - You cannot go there.");
                                    }

                                    m_IsValidMove = false;
                                }
                            }
                            else
                            {
                                if (m_Player.IsHuman)
                                {
                                    Console.WriteLine("Invalid move - You have to make a jump");
                                }

                                m_IsValidMove = false;
                            }
                        }
                    }
                    //King
                    else
                    {
                        m_IsJump = isKingJump();
                        if (m_IsJump)
                        {
                            m_IsValidMove = isValidJump();
                        }
                        else
                        {
                            if (!hasToEat())
                            {
                                if (isValidKingMove())
                                {
                                    m_IsValidMove = true;
                                }
                                else
                                {
                                    if (m_Player.IsHuman)
                                    {
                                        Console.WriteLine("Invalid move - You cannot go there.");
                                    }

                                    m_IsValidMove = false;
                                }
                            }
                            else
                            {
                                if (m_Player.IsHuman)
                                {
                                    Console.WriteLine("Invalid move - You have to make a jump");
                                }

                                m_IsValidMove = false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (m_Player.IsHuman)
                {
                    Console.WriteLine("Invalid source");
                }
                m_IsValidMove = false;
            }
            
        }


        /** ORIGINAL
         *
         */
        private void isValidMove(string i_Move)
        {
            if (isLegalFormatMove(i_Move))
            {
                if (!i_Move.Equals("Q"))
                {
                    setCoordinates(i_Move);
                    Cell.eCellState sourceState = m_CurrentBoard.GetCellContent(m_Source);
                    Cell.eCellState destinationState = m_CurrentBoard.GetCellContent(m_Destination);

                    if (isValidSourceType(sourceState) && IsValidDestination(destinationState))
                    {
                        m_IsMan = sourceState == Cell.eCellState.O || sourceState == Cell.eCellState.X;
                        if (m_IsMan)
                        {
                            m_IsJump = isManJump();
                            if (m_IsJump)
                            {
                                m_IsValidMove = isValidJump();
                            }
                            else
                            {
                                if (!hasToEat())
                                {
                                    if (isValidManMove())
                                    {
                                        m_IsValidMove = true;
                                    }
                                    else
                                    {
                                        if (m_Player.IsHuman)
                                        {
                                            Console.WriteLine("Invalid move - You cannot go there.");
                                        }
                                        m_IsValidMove = false;
                                    }
                                }
                                else
                                {
                                    if (m_Player.IsHuman)
                                    {
                                        Console.WriteLine("Invalid move - You have to make a jump");
                                    }
                                    m_IsValidMove = false;
                                }
                            }
                        }
                        //King
                        else
                        {
                            m_IsJump = isKingJump();
                            if (m_IsJump)
                            {
                                m_IsValidMove = isValidJump();
                            }
                            else
                            {
                                if (!hasToEat())
                                {
                                    if (isValidKingMove())
                                    {
                                        m_IsValidMove = true;
                                    }
                                    else
                                    {
                                        if (m_Player.IsHuman)
                                        {
                                            Console.WriteLine("Invalid move - You cannot go there.");
                                        }
                                        m_IsValidMove = false;
                                    }
                                }
                                else
                                {
                                    if (m_Player.IsHuman)
                                    {
                                        Console.WriteLine("Invalid move - You have to make a jump");
                                    }
                                    m_IsValidMove = false;
                                }
                            }
                        }

                    }
                    else
                    {
                        if (m_Player.IsHuman)
                        {
                            Console.WriteLine("Invalid source");
                        }
                        m_IsValidMove = false;
                    }
                }
                //To quit
                else
                {
                    m_IsValidMove = true;
                    m_ToQuit = true;

                }
            }
            else
            {
                if (m_Player.IsHuman)
                {
                    Console.WriteLine("Invalid move format");
                }
                m_IsValidMove = false;
            }
        }

        public bool IsValidDestination(Cell.eCellState i_IsEmpty)
        {
            return i_IsEmpty == Cell.eCellState.Empty;
        }

        private bool isManJump()
        {
            return (((m_Destination.Row < m_Source.Row - 1) && (m_Player.Color == Player.PlayerColor.Black)) ||
                    ((m_Destination.Row > m_Source.Row + 1) && (m_Player.Color == Player.PlayerColor.White)));
        }

        private bool isKingJump()
        {
            return (m_Destination.Row > m_Source.Row + 1) ||
                   (m_Destination.Row < m_Source.Row - 1);
        }

        private bool hasToEat()
        {
            bool result = false;
            foreach (Game.Coordinate checker in m_Player.m_PlayerCheckers)
            {
                if (hasToEat(checker))
                {
                    result = true;
                    break;
                }
            }

            return result;

        }

        public bool hasToEat(Game.Coordinate i_Checker)
        {
            bool result = false;
            if (m_CurrentBoard.GetCellContent(i_Checker) == Cell.eCellState.X)
            {
                Game.Coordinate left = new Game.Coordinate(i_Checker.Row - 1, i_Checker.Col - 1);
                Game.Coordinate right = new Game.Coordinate(i_Checker.Row - 1, i_Checker.Col + 1);
                Game.Coordinate leftDest = new Game.Coordinate(i_Checker.Row - 2, i_Checker.Col - 2);
                Game.Coordinate rightDest = new Game.Coordinate(i_Checker.Row - 2, i_Checker.Col + 2);
                if (isValidCoordinate(left) && hasOpponentChecker(left) && isValidCoordinate(leftDest) && isEmptyCoordinate(leftDest))
                {
                    result = true;

                }

                else if (isValidCoordinate(right) && hasOpponentChecker(right) && isValidCoordinate(rightDest) && isEmptyCoordinate(rightDest))
                {

                    result = true;

                }
            }
            else if (m_CurrentBoard.GetCellContent(i_Checker) == Cell.eCellState.O)
            {
                Game.Coordinate left = new Game.Coordinate(i_Checker.Row + 1, i_Checker.Col - 1);
                Game.Coordinate right = new Game.Coordinate(i_Checker.Row + 1, i_Checker.Col + 1);
                Game.Coordinate leftDest = new Game.Coordinate(i_Checker.Row + 2, i_Checker.Col - 2);
                Game.Coordinate rightDest = new Game.Coordinate(i_Checker.Row + 2, i_Checker.Col + 2);
                if (isValidCoordinate(left) && hasOpponentChecker(left) && isValidCoordinate(leftDest) && isEmptyCoordinate(leftDest))
                {
                    result = true;
                
                }

                else if (isValidCoordinate(right) && hasOpponentChecker(right) && isValidCoordinate(rightDest) && isEmptyCoordinate(rightDest))
                {

                    result = true;
                }

            }
            else
            {
                Game.Coordinate leftBottom = new Game.Coordinate(i_Checker.Row - 1, i_Checker.Col - 1);
                Game.Coordinate rightBottom = new Game.Coordinate(i_Checker.Row - 1, i_Checker.Col + 1);
                Game.Coordinate leftUp = new Game.Coordinate(i_Checker.Row + 1, i_Checker.Col - 1);
                Game.Coordinate rightUp = new Game.Coordinate(i_Checker.Row + 1, i_Checker.Col + 1);
                Game.Coordinate leftBottomDest = new Game.Coordinate(i_Checker.Row - 2, i_Checker.Col - 2);
                Game.Coordinate rightBottomDest = new Game.Coordinate(i_Checker.Row - 2, i_Checker.Col + 2);
                Game.Coordinate leftUpDest = new Game.Coordinate(i_Checker.Row + 2, i_Checker.Col - 2);
                Game.Coordinate rightUpDest = new Game.Coordinate(i_Checker.Row + 2, i_Checker.Col + 2);

                if (isValidCoordinate(leftBottom) && hasOpponentChecker(leftBottom) && isValidCoordinate(leftBottomDest) && isEmptyCoordinate(leftBottomDest))
                {
                    result = true;

                }

                else if (isValidCoordinate(rightBottom) && hasOpponentChecker(rightBottom) && isValidCoordinate(rightBottomDest) && isEmptyCoordinate(rightBottomDest))
                {

                    result = true;
                }

                else if (isValidCoordinate(leftUp) && hasOpponentChecker(leftUp) && isValidCoordinate(leftUpDest) && isEmptyCoordinate(leftUpDest))
                {
                    result = true;
                }

                else if (isValidCoordinate(rightUp) && hasOpponentChecker(rightUp) && isValidCoordinate(rightUpDest) && isEmptyCoordinate(rightUpDest))
                {

                    result = true;
                }
            }

            return result;
        }

        private bool isEmptyCoordinate(Game.Coordinate i_Coordinate)
        {
           return m_CurrentBoard.GetCellContent(i_Coordinate) == Cell.eCellState.Empty;
        }

        public bool isValidCoordinate(Game.Coordinate coordinate)
        {
            return ((coordinate.Row >= 0) && (coordinate.Row < m_CurrentBoard.GetSize())) &&
                   ((coordinate.Col >= 0) && (coordinate.Col < m_CurrentBoard.GetSize()));
        }

        /** Assumes the direction with respect to the i_Player's color have been checked. **/
        private bool isValidJump()
        {
            bool result = false;
            bool goingLeft = m_Destination.Col == m_Source.Col - 2;
            bool goingRight = m_Destination.Col == m_Source.Col + 2;
            Game.Coordinate toEat = new Game.Coordinate(0, 0);
            if ((m_Destination.Row == m_Source.Row + 2))
            {
                if (goingLeft)
                {
                    toEat.Row = m_Source.Row + 1;
                    toEat.Col = m_Source.Col - 1;
                    result = hasOpponentChecker(toEat);
                }
                else if (goingRight)
                {
                    toEat.Row = m_Source.Row + 1;
                    toEat.Col = m_Source.Col + 1;
                    result = hasOpponentChecker(toEat);
                }
            }
            else if ((m_Destination.Row == m_Source.Row - 2))
            {
                if (goingLeft)
                {
                    toEat.Row = m_Source.Row - 1;
                    toEat.Col = m_Source.Col - 1;
                    result = hasOpponentChecker(toEat);
                }
                else if (goingRight)
                {
                    toEat.Row = m_Source.Row - 1;
                    toEat.Col = m_Source.Col + 1;
                    result = hasOpponentChecker(toEat);
                   
                }
            }
            if (result)
            {
                m_ToEat = toEat;
            }
            return result;
        }

        private bool hasOpponentChecker(Game.Coordinate coordinate)
        {
            bool result;
            if (m_Player.Color == Player.PlayerColor.Black)
            {
                result = (m_CurrentBoard.GetCellContent(coordinate) == Cell.eCellState.O ||
                          m_CurrentBoard.GetCellContent(coordinate) == Cell.eCellState.U);
            }
            else
            {
                result = (m_CurrentBoard.GetCellContent(coordinate) == Cell.eCellState.X ||
                          m_CurrentBoard.GetCellContent(coordinate) == Cell.eCellState.K);
            }

            return result;
        }



        public bool isValidSourceType(Cell.eCellState i_Source)
        {
            return (m_Player.Color == Player.PlayerColor.Black &&
                    (i_Source == Cell.eCellState.X || i_Source == Cell.eCellState.K)) ||
                   (m_Player.Color == Player.PlayerColor.White &&
                    (i_Source == Cell.eCellState.O || i_Source == Cell.eCellState.U));
        }


        private bool isValidKingMove()
        {
            int colDifference = m_Destination.Col - m_Source.Col;
            return ((m_Destination.Row == m_Source.Row + 1)
                    || (m_Destination.Row == m_Source.Row - 1))
                   && (colDifference == -1 || colDifference == 1);
        }

        private bool isValidManMove()
        {
            int colDifference = m_Destination.Col - m_Source.Col;
            return ((m_Destination.Row == m_Source.Row - 1) && (m_Player.Color == Player.PlayerColor.Black)
                    || (m_Destination.Row == m_Source.Row + 1) && (m_Player.Color == Player.PlayerColor.White))
                   && (colDifference == -1 || colDifference == 1);
        }

        public bool ToQuit
        {
            get { return m_ToQuit; }
        }
        public bool IsJump
        {
            get { return m_IsJump;}
        }
        public Game.Coordinate Source
        {
            get { return m_Source; }
        }
        public Game.Coordinate Destination
        {
            get { return m_Destination; }
        }
        public Game.Coordinate ToEat
        {
            get { return m_ToEat; }
        }
        public Player Player
        {
            get { return m_Player; }
        }
        public string Input
        {
            get { return m_Input; }
        }
    }
}
