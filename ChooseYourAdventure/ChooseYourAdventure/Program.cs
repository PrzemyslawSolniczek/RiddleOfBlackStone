using ChooseYourAdventure.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool endOfGame = false;
            int userChoice = 0;

            while (!endOfGame)
            {
                ShowMenu(userChoice);

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        // Dodajemy 4, aby zapewnic, ze wartosc jest dodatnia
                        userChoice = (userChoice - 1 + 4) % 4; 
                        break;
                    case ConsoleKey.DownArrow:
                        userChoice = (userChoice + 1) % 4;
                        break;
                    case ConsoleKey.Enter:
                        switch (userChoice)
                        {
                            case 0:
                                  NewGame();
                                break;
                            case 1:
                                  About();
                                break;
                            case 2:
                                // Opcje();
                                break;
                            case 3:
                                endOfGame = true;
                                break;
                        }
                        break;
                }
            }
        }

        static void ShowMenu(int userChoice)
        {
            Console.Clear();
            //TUTAJ DODAC TEKST ASCII
            Console.WriteLine("Witaj w grze Choose Your Adventure!" + '\n');

            ShowStone();

            const int menuWidth = 26;
            Console.WriteLine($"╔{new string('═', menuWidth - 2)}╗");


            string[] options =
            {
                "Rozpocznij nową grę",
                "O autorach",
                "Opcje",
                "Wyjdź z gry"
            };

            for (int i = 0; i < options.Length; i++)
            {
                Console.Write("║ ");

                if (i == userChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">> {options[i].PadRight(menuWidth - 6)}║");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"   {options[i].PadRight(menuWidth - 6)}║");
                }
            }
            Console.WriteLine($"║{new string(' ', menuWidth - 2)}║");
            Console.WriteLine($"╚{new string('═', menuWidth - 2)}╝");
        }

        
        static void NewGame()
        {
            GameController gameControl = new GameController();
            gameControl.StartGame();
        }
        

        static void About()
        {
            Console.Clear();
            Console.WriteLine("Autorzy: " + '\n');
            Console.WriteLine("> Przemysław Solniczek");
            Console.WriteLine("> Albert Stefanowski" + '\n');
            Console.WriteLine("Wciśnij dowolny klawisz, aby wrócić do menu...");
            Console.ReadKey();
        }



        ////// WZORKI ///////
        static void ShowStone()
        {
            string[] stone =
            {
                "  .-=-. ",
                " /  *  \\",
                "( * | * )",
                " \\  *  /",
                "  `-=-' "
            };

            foreach (string line in stone)
            {
                Console.WriteLine(line);
            }
        }
    }
}
