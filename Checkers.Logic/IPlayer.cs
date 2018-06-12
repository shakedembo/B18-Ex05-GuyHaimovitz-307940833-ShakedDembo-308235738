using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Logic
{
    public interface IPlayer
    {
        void AddPiece(IPiece i_Piece);
        bool RemovePiece(IPiece i_Piece);
        bool DoesContain(IPiece i_Piece);

        PlayerColor Color { get; }
        List<IPiece> Pieces { get; set; }
    }
}
