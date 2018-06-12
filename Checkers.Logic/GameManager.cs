using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Logic
{
    public class GameManager
    {
        private IPlayer m_Player1;
        private IPlayer m_Player2;
        private Game m_CurrentGame;

        private int m_BoardSize;

        private int m_PlayerOneScore = 0;
        private int m_PlayerTwoScore = 0;

        public GameManager(string i_Player1Name, string i_Player2Name,bool i_TwoPlayers, int i_BoardSize)
        {
            m_Player1 = new HumanPlayer(i_Player1Name, PlayerColor.Black);
            m_BoardSize = i_BoardSize;
            if (i_TwoPlayers)
            {
                m_Player2 = new HumanPlayer(i_Player2Name, PlayerColor.White);
            }
            else
            {
                m_Player2 = new PcPlayer("Computer");
            }

            StartNewGame();
  
        }

        private void updateScores(Tuple<IPlayer, int> i_PlayerAndScore)
        {
            if (i_PlayerAndScore.Item1.Equals(Player1))
            {
                m_PlayerOneScore += i_PlayerAndScore.Item2;
            }
            else if (i_PlayerAndScore.Item1.Equals(Player2))
            {
                m_PlayerTwoScore += i_PlayerAndScore.Item2;
            }
        }

        private void gameEndedHandler()
        {
            updateScores(m_CurrentGame.calculateScore());
        }

        public void StartNewGame()
        {
            Player1.Pieces = new List<IPiece>();
            Player2.Pieces = new List<IPiece>();
            m_CurrentGame = new Game(Player1, Player2, BoardSize);
            m_CurrentGame.GameEnded += gameEndedHandler;
        }

        public Game CurrentGame
        {
            get { return m_CurrentGame; }
        }

        public IPlayer Player1
        {
            get { return m_Player1; }
        }
        public IPlayer Player2
        {
            get { return m_Player2; }
        }

        public int Player1Score
        {
            get { return m_PlayerOneScore; }
            set { m_PlayerOneScore = value; }
        }

        public int Player2Score
        {
            get { return m_PlayerTwoScore; }
            set { m_PlayerTwoScore = value; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
        }
    }
}
