using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Logic
{
    class Program
    {
        public static void Main()
        {
            //string userName1 = getUserName();
            //int boardSize = getBoardSize();
            //int numberOfPlayers = getNumberOfPlayers();
            
            //string userName2 = "PC";
            //if (numberOfPlayers == 2)
            //{
            //    userName2 = getUserName();
            //}
            //GameManager game = new GameManager(userName1, userName2, boardSize, numberOfPlayers);
            
        }

        static string getUserName()
        {
            Console.WriteLine("Please enter your first name: ");
            string userName = Console.ReadLine();
            while (userName.Contains(" ") || userName.Length > 20)
            {
                Console.WriteLine("Specify a first name as one word that contains at most 20 characters: ");
                userName = Console.ReadLine();
            }
            return userName;
        }

        static int getBoardSize()
        {
            Console.WriteLine("What size of board do you want to play on? (6, 8, 10): ");
            int boardSize;
            int.TryParse(Console.ReadLine(), out boardSize);

            while (!(boardSize == 6 || boardSize == 8 || boardSize == 10))
            {
                Console.WriteLine("Please choose a board size within those numbers 6, 8 or 10: ");
                int.TryParse(Console.ReadLine(), out boardSize);
            }

            return boardSize;
        }
        static int getNumberOfPlayers()
        {
            Console.WriteLine("How many players (1 / 2): ");
            int numberOfPlayers;
            int.TryParse(Console.ReadLine(), out numberOfPlayers);

            while (!(numberOfPlayers == 2 || numberOfPlayers == 1))
            {
                Console.WriteLine("Please insert a number of either 1 or 2: ");
                int.TryParse(Console.ReadLine(), out numberOfPlayers);
            }
            return numberOfPlayers;
        }
    }
}
