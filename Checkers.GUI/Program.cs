using Checkers.Logic;

namespace Checkers.GUI
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();
            GameManager game = new GameManager(gameSettings.Player1, gameSettings.Player2, gameSettings.IsTwoPlayers, gameSettings.BoardSize);
            GameUI gameUi = new GameUI(game);
            gameUi.ShowDialog();
        }
    }
}
