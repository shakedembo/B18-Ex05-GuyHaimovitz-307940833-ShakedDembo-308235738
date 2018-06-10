using Checkers.GUI;
using Checkers;
using Checkers.Logic;

namespace Checkers
{
    class Program
    {


        public static void Main(string[] args)
        {
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();
           GameManager1 game = new GameManager1(gameSettings.Player1, gameSettings.Player2, gameSettings.IsTwoPlayers, gameSettings.BoardSize);
        }
    }
}
