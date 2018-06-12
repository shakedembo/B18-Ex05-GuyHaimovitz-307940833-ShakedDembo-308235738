using System;
using System.Collections.Generic;

namespace Checkers.Logic
{
    class PcPlayer : IPlayer
    {
        public void AddPiece(IPiece i_Piece)
        {
            throw new NotImplementedException();
        }

        public bool RemovePiece(IPiece i_Piece)
        {
            throw new NotImplementedException();
        }

        public bool DoesContain(IPiece i_Piece)
        {
            throw new NotImplementedException();
        }

        public PlayerColor Color { get; }
        public List<IPiece> Pieces { get; set; }
    }
}