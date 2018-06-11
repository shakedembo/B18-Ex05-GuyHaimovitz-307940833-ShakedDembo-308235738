using System;

namespace Checkers
{
    class PieceX : IPiece
    {
        private bool m_IsKing;
        private Tuple<int, int> m_CurrentPosition;

        public PieceX(Tuple<int, int> i_Position)
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

        public Tuple<int, int> Position
        {
            set { this.m_CurrentPosition = value; }
        }

        public int Col
        {
            get { return m_CurrentPosition.Item2; }
        }
        public int Row
        {
            get { return m_CurrentPosition.Item1; }
        }

        public override string ToString()
        {
            return m_IsKing ? "K" : "X";
        }

    }
}