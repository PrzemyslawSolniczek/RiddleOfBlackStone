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
                        // Dodajemy 4, aby zapewnić, że wartość jest dodatnia
                        userChoice = (userChoice - 1 + 4) % 4; 
                        break;
                    case ConsoleKey.DownArrow:
                        userChoice = (userChoice + 1) % 4;
                        break;
                    case ConsoleKey.Enter:
                        switch (userChoice)
                        {
                            case 0:
//                                RozpocznijNowaGre();
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
            //TUTAJ DODAĆ TEKST ASCII
            Console.WriteLine("Witaj w grze Choose Your Adventure!" + '\n');

            string[] options =
            {
                "Rozpocznij nową grę",
                "O autorach",
                "Opcje",
                "Wyjdź z gry"
            };

            for (int i = 0; i < options.Length; i++)
            {
                if (i == userChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(options[i]);
                }
            }
        }

        
        static void NewGame()
        {
            var gameControl = new GameController();
            //gameControl.Start();
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
    }
}
