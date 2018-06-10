using System;

namespace Checkers
{
    class PieceX : IPiece
    {
        private bool m_IsKing;
        private Tuple<int, int> m_CurrentPosition;

        public void kingMe()
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

        public override string ToString()
        {
            return m_IsKing ? "K" : "X";
        }
    }
}