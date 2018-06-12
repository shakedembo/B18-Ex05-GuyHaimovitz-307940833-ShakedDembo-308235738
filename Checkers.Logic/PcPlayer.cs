using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers.Logic
{
    class PcPlayer : IPlayer
    {
        private string m_Name;
        private PlayerColor m_Color;
        private List<IPiece> m_Pieces;

        public PcPlayer(string i_Name)
        {
            m_Name = i_Name;
            m_Color = PlayerColor.White;
            m_Pieces = new List<IPiece>();
        }

        public Move GetMove(Game i_Game)
        {
            List<Move> possibleMoves = Game.checkPossibleMoves(i_Game, m_Color);
            Random rnd = new Random();
            

            int RandomIndex = rnd.Next(0, possibleMoves.Count - 1);


            return possibleMoves[RandomIndex];
        }

        public void getNextMoveFromPc(Game i_Game, Move i_LastMove)
        {
            if (i_Game.CurrentPlayer.Pieces.Count > 0)
            {
                Move PCmove = (i_Game.CurrentPlayer as PcPlayer).GetNextMove(i_Game, i_LastMove);
                i_Game.MakeMove(PCmove.Source, PCmove.Destination);
            }
        }

        internal static IEnumerable<Move> possibleNextMoves(Game i_Game, Move i_LastMove)
        {
            List<Move> allPossibleMoves = Game.checkPossibleMoves(i_Game, i_Game.CurrentPlayer.Color);
            return allPossibleMoves.Where(move => move.Source.Equals(i_LastMove.Destination));
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
            set { m_Pieces = value; }
        }

        public override string ToString()
        {
            return this.m_Name;
        }

        public Move GetNextMove(Game i_Game, Move i_LastMove)
        {
            List<Move> possibleMoves = possibleNextMoves(i_Game, i_LastMove).ToList();
            Random rnd = new Random();

            int RandomIndex = rnd.Next(0, possibleMoves.Count - 1);
            
            return possibleMoves[RandomIndex];
        }
    }
}