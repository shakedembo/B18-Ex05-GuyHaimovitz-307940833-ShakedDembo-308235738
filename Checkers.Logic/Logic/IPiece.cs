using System;

namespace Checkers
{
    public interface IPiece
    {
        void kingMe();
        bool isKing();

        int Col { get; }
        int Row { get; }

        Tuple<int, int> Position { set; }

    }
}