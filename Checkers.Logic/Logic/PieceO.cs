namespace Checkers
{
    class PieceO : IPiece
    {
        private bool m_IsKing;

        public void kingMe()
        {
            m_IsKing = true;
        }

        public bool isKing()
        {
            return m_IsKing;
        }

        public override string ToString()
        {
            return m_IsKing ? "U" : "O";
        }
    }
}