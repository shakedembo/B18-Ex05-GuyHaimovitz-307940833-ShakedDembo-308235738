using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace Checkers.GUI
{
    class Program
    {


        public static void Main(string[] args)
        {
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();

            GameManager game = new GameManager(gameSettings.Player1, gameSettings.Player2, gameSettings.BoardSize, gameSettings.NumberOfPlayers);
        }
    }
}
