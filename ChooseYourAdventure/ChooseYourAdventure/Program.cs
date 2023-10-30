using ChooseYourAdventure.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure
{
    internal class Program
    {
        // zmienna do ustawienia trybu wypisywania tekstu w scenach
        public static bool DisplayTextLetterByLetter = true;
        // zmienna wlaczajaca muzke
        public static bool Music = true;
        //private static SoundPlayer player = new SoundPlayer("D:\\Studia\\Semestr V\\KCK\\Projekt\\ChooseYourAdventure\\ChooseYourAdventure\\mario_10min.wav");


        static void Main(string[] args)
        {
            //PlayMusic();

            bool endOfGame = false;
            int userChoice = 0;

            while (!endOfGame)
            {
                ShowMenu(userChoice);

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        // dodajemy 4, aby zapewnic, ze wartosc jest dodatnia
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
                                OptionsPanel();
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

            Console.WriteLine("Riddle Of Black Stone");

            //ShowTitle();
            ShowStone();

            const int menuWidth = 26;
            Console.WriteLine($"╔{new string('═', menuWidth - 2)}╗");
            Console.WriteLine($"|{"Menu Główne".PadLeft((menuWidth + "Menu Główne".Length) / 2).PadRight(menuWidth - 2)}|");
            Console.WriteLine($"╠{new string('═', menuWidth - 2)}╣");


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

            const int frameWidth = 25; // ustawiamy szerokosc ramki

            Console.WriteLine($"+{new string('~', frameWidth - 2)}+");

            // tytul
            int paddingSize = (frameWidth - "Autorzy:".Length) / 2;
            Console.WriteLine($"|{new string(' ', paddingSize)}Autorzy:{new string(' ', frameWidth - paddingSize - "Autorzy:".Length - 2)}|");
            Console.WriteLine("|                       |");

            // autorzy
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"| Przemysław Solniczek |");
            Console.ResetColor();
            Console.WriteLine($"+{new string('~', frameWidth - 2)}+");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"| Albert Stefanowski   |");
            Console.ResetColor();
            Console.WriteLine("|                       |");

            Console.WriteLine($"+{new string('~', frameWidth - 2)}+");

            Console.WriteLine("Naciśnij dowolny klasiwsz by wrócić");

            Console.ReadKey();
        }

        static void OptionsPanel()
        {
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();

                const int menuWidth = 31;
                Console.WriteLine($"╔{new string('═', menuWidth - 2)}╗");
                Console.WriteLine($"|{"Ustawienia".PadLeft((menuWidth + "Ustawienia".Length) / 2).PadRight(menuWidth - 2)}|"); // Wysrodkowany tytul
                Console.WriteLine($"╠{new string('═', menuWidth - 2)}╣");


                string displayMode = DisplayTextLetterByLetter ? "Wygląd: Litera po literze" : "Wygląd: Tekst od razu";
                string music = Music ? "Dźwięk: Włączony" : "Dźwięk: Wyłączony";

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
                                Music = !Music;
                                //PlayMusic();
                                break;
                            case 1:
                                // wyglad
                                DisplayTextLetterByLetter = !DisplayTextLetterByLetter;
                                break;
                            case 2:
                                // Powrot
                                return;
                        }
                        break;
                }
            }
        }


        // MUZYKA //
 /*
        public static void PlayMusic()
        {
            if (Music)
            {
                player.PlayLooping();
            }
            else
            {
                player.Stop();
            }
        }
 */

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

        static void ShowTitle()
        {
            Console.WriteLine(".______       __   _______   _______   __       _______      ______    _______    .______    __           ___        ______  __  ___         _______..___________.  ______   .__   __.  _______ ");
            Console.WriteLine("|   _  \\     |  | |       \\ |       \\ |  |     |   ____|    /  __  \\  |   ____|   |   _  \\  |  |         /   \\      /      ||  |/  /        /       ||           | /  __  \\  |  \\ |  | |   ____|");
            Console.WriteLine("|  |_)  |    |  | |  .--.  ||  .--.  ||  |     |  |__      |  |  |  | |  |__      |  |_)  | |  |        /  ^  \\    |  ,----'|  '  /        |   (----``---|  |----`|  |  |  | |   \\|  | |  |__   \r\n");
            Console.WriteLine("|      /     |  | |  |  |  ||  |  |  ||  |     |   __|     |  |  |  | |   __|     |   _  <  |  |       /  /_\\  \\   |  |     |    <          \\   \\        |  |     |  |  |  | |  . `  | |   __|  \r\n");
            Console.WriteLine("|  |\\  \\----.|  | |  '--'  ||  '--'  ||  `----.|  |____    |  `--'  | |  |        |  |_)  | |  `----. /  _____  \\  |  `----.|  .  \\     .----)   |       |  |     |  `--'  | |  |\\   | |  |____ \r\n");
            Console.WriteLine("| _| `._____||__| |_______/ |_______/ |_______||_______|    \\______/  |__|        |______/  |_______|/__/     \\__\\  \\______||__|\\__\\    |_______/        |__|      \\______/  |__| \\__| |_______|\r\n");
        }
    }
}
