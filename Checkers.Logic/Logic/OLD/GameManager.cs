using System;

namespace Checkers
{
    public class GameManager
    {
        private Player m_Player1;
        private Player m_Player2;

        private int m_PlayerOneScore = 0;
        private int m_PlayerTwoScore = 0;


        public GameManager(string i_One, string i_Two, int i_BoardSize, int numberOfPlayers)
        {
            m_Player1 = new Player(i_One, Player.PlayerColor.Black, true);
            if (numberOfPlayers == 2)
            {
                m_Player2 = new Player(i_Two, Player.PlayerColor.White, true);
            }
            else
            {
                m_Player2 = new PcPlayer_Old(i_Two, Player.PlayerColor.White, false);
            }

            bool wantToContinue = true;
            while (wantToContinue)
            {
                Game game = new Game(m_Player1, m_Player2, i_BoardSize, numberOfPlayers);
                GUI.GameUI testGame = new GUI.GameUI(game);
                testGame.ShowDialog();
                Tuple<int, Player> LastGameResult = game.StartGame();

                if (LastGameResult.Item2 == m_Player1)
                {
                    m_PlayerOneScore += LastGameResult.Item1;
                }
                else
                {
                    m_PlayerTwoScore += LastGameResult.Item1;
                }
                printScores();
                Console.Write("Would you like to do another game [Y/N]: ");
                string ToContinue = Console.ReadLine();
                if (ToContinue.Equals("N"))
                {
                    wantToContinue = false;
                }
            }

            printScores();
            Console.Write("Press any key to exit...");
            Console.ReadLine();
        }

        private void printScores()
        {
            Console.Clear();
            Console.WriteLine(m_Player1.Name + "'s Final Score: " + m_PlayerOneScore);
            Console.WriteLine(m_Player2.Name + "'s Final Score: " + m_PlayerTwoScore);
        }
    }
}
