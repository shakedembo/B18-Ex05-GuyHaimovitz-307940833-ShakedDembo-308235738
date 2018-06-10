namespace Checkers
{
    class PieceX : IPiece
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
            return m_IsKing ? "K" : "X";
        }
    }
}