using System;

namespace Checkers.Logic
{
    class PieceO : IPiece

    {
        private bool m_IsKing;
        private Tuple<int, int> m_CurrentPosition;

        public PieceO(Tuple<int, int> i_Position)
        {
            this.m_CurrentPosition = i_Position;
            this.m_IsKing = false;
        }

        public void KingMe()
        {
            m_IsKing = true;
        }

        public bool isKing()
        {
            return m_IsKing;
        }

        public int Col
        {
            get { return m_CurrentPosition.Item2; }
        }
        public int Row
        {
            get { return m_CurrentPosition.Item1; }
        }

        public Tuple<int, int> Position
        {
            set { this.m_CurrentPosition = value; }
        }

        public override string ToString()
        {
            return m_IsKing ? "U" : "O";
        }
    }
}