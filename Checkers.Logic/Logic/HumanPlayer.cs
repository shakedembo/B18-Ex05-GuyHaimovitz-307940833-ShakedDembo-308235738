using System.Collections.Generic;

namespace Checkers.Logic
{
    class HumanPlayer : IPlayer
    {

        private string m_Name;
        private PlayerColor m_Color;
        private List<IPiece> m_Pieces;

        public HumanPlayer(string i_Name, PlayerColor i_Color)
        {
            this.m_Name = i_Name;
            this.m_Color = i_Color;
            this.m_Pieces = new List<IPiece>();
        }

        public void AddPiece(IPiece i_Piece)
        {
            this.m_Pieces.Add(i_Piece);
        }

        public bool RemovePiece(IPiece i_Piece)
        {
            return this.m_Pieces.Remove(i_Piece);
        }

        public bool DoesContain(IPiece i_Piece)
        {
            return m_Pieces.Contains(i_Piece);
        }
        

        public string Name
        {
            get { return m_Name; }
        }

        public PlayerColor Color
        {
            get { return m_Color; }
        }
        public List<IPiece> Pieces
        {
            get { return m_Pieces; }
        }

        public override string ToString()
        {
            return this.m_Name;
        }
    }
}