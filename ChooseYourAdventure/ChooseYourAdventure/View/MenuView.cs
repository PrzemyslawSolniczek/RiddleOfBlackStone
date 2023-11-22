using ChooseYourAdventure.Controller;
using ChooseYourAdventure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.View
{
    public class MenuView : IMenuView
    {
        public void ShowMenu(IMenuModel mn)
        {

            if (mn.Check == false)
            {
                PrintingAscii.FirstScreen();
                mn.Check = true;
            }
            PrintingAscii.Title();
            const int menuWidth = 26;
            Console.WriteLine($"\t\t\t\t\t\t╔{new string('═', menuWidth - 2)}╗");
            Console.WriteLine($"\t\t\t\t\t\t|{"Menu Główne".PadLeft((menuWidth + "Menu Główne".Length) / 2).PadRight(menuWidth - 2)}|");
            Console.WriteLine($"\t\t\t\t\t\t╠{new string('═', menuWidth - 2)}╣");


            string[] options =
            {
                "Rozpocznij nową grę",
                mn.LoadGame,
                "O autorach",
                "Opcje",
                "Wyjdź z gry"
            };

            for (int i = 0; i < options.Length; i++)
            {
                Console.Write("\t\t\t\t\t\t║ ");

                if (i == mn.UserChoice)
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
            Console.WriteLine($"\t\t\t\t\t\t║{new string(' ', menuWidth - 2)}║");
            Console.WriteLine($"\t\t\t\t\t\t╚{new string('═', menuWidth - 2)}╝");
        }
        public void NewGame(GameController gameController, IMenuModel mn)
        {
            mn.LoadGame = "Wczytaj grę";
            gameController.StartGame();
        }
        public void LoadGame(GameController gameController, IMenuModel mn)
        {
            mn.LoadGame = "Wczytano grę";
            gameController.Load();
        }
        public void About()
        {
            Console.Clear();
            PrintingAscii.Authors();
            Console.ReadKey();
        }
        public void OptionsPanel(IMenuModel mn)
        {
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();

                const int menuWidth = 31;
                Console.WriteLine($"╔{new string('═', menuWidth - 2)}╗");
                Console.WriteLine($"|{"Ustawienia".PadLeft((menuWidth + "Ustawienia".Length) / 2).PadRight(menuWidth - 2)}|"); // Wysrodkowany tytul
                Console.WriteLine($"╠{new string('═', menuWidth - 2)}╣");


                string displayMode = mn.DisplayTextLetterByLetter ? "Wygląd: Litera po literze" : "Wygląd: Tekst od razu";
                string music = mn.Music ? "Dźwięk: Włączony" : "Dźwięk: Wyłączony";


                string[] options =
                {
                    music,
                    displayMode,
                    "Powrót"
                };

                for (int i = 0; i < options.Length; i++)
                {
                    Console.Write("║ ");
                    if (i == selectedOption)
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

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = Math.Max(0, selectedOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = Math.Min(options.Length - 1, selectedOption + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (selectedOption)
                        {
                            case 0:
                                // dzwiek
                                mn.Music = !mn.Music;
                                PlayMusic(mn.SoundPlayer, mn);
                                break;
                            case 1:
                                // wyglad
                                mn.DisplayTextLetterByLetter = !mn.DisplayTextLetterByLetter;
                                break;
                            case 2:
                                // Powrot
                                return;
                        }
                        break;
                }
            }
        }
        public void PlayMusic(SoundPlayer player, IMenuModel mn)
        {
            if (mn.Music)
            {
                player.PlayLooping();
            }
            else
            {
                player.Stop();
            }
        }
    }
}
