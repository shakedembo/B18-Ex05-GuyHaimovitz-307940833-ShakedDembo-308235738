using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Logic
{
    class GameManager
    {
        private IPlayer m_Player1;
        private IPlayer m_Player2;

        private int m_PlayerOneScore = 0;
        private int m_PlayerTwoScore = 0;

        public GameManager(string i_Player1Name, string i_Player2Name,bool i_TwoPlayers, int i_BoardSize)
        {
            m_Player1 = new HumanPlayer(i_Player1Name, PlayerColor.Black);

            if (i_TwoPlayers)
            {
                m_Player2 = new HumanPlayer(i_Player2Name, PlayerColor.White);
            }
            else
            {
                m_Player2 = new PcPlayer();
            }
            
            while (true)
            {
                Game game = new Game(m_Player1, m_Player2, i_BoardSize);
                game.StartGame();
            }
        }

    }
}
