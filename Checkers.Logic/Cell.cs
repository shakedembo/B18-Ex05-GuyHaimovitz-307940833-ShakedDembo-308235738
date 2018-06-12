using System;
using System.Deployment.Internal;
using System.Threading;

namespace Checkers.Logic
{
    public class Cell
    {
        private IPiece m_Piece;
        private Tuple<int, int> m_Position;


        public Cell(Tuple<int, int> i_Position)
        {
            this.m_Position = i_Position;

        }

        public IPiece Piece
        {
            get { return m_Piece; }
            set { m_Piece = value; }
        }

        public int Col
        {
            get { return m_Position.Item2; }
        }
        public int Row
        {
            get { return m_Position.Item1; }
        }

        public Tuple<int, int> Position
        {
            set { this.Position = value; }
        }

        public override string ToString()
        {
            return this.Piece == null ? " " : this.Piece.ToString();
        }
    }
}
