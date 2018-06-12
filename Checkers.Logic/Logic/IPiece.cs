using System;
using System.Collections.Generic;
using Checkers.Logic;

namespace Checkers
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