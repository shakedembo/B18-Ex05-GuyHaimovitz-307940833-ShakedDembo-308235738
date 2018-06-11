﻿using System;

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