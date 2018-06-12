using System;
using System.Collections.Generic;

namespace Checkers.Logic
{
    public interface IPiece
    {
        void KingMe();
        bool isKing();

        int Col { get; }
        int Row { get; }

        Tuple<int, int> Position { set; }

    }
}