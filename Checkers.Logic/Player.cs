using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkers.Logic
{ 

    class Player
    {
        public enum PlayerColor
        {
            White,
            Black
        }

        private string m_Name;
        private PlayerColor m_Color;
        private bool m_IsHuman;
        internal List<Game.Coordinate> m_PlayerCheckers;

        public Player(string i_Name, PlayerColor i_Color, bool i_IsHuman)
        {
            this.m_Name = i_Name;
            this.m_Color = i_Color;
         
            this.m_IsHuman = i_IsHuman;
            this.m_PlayerCheckers = new List<Game.Coordinate>();
        }
        
        public string Name
        {
            get { return m_Name; }
        }

        public PlayerColor Color
        {
            get { return m_Color; }
        }

        public bool IsHuman
        {
            get { return m_IsHuman; }
        }
    }

    
}
