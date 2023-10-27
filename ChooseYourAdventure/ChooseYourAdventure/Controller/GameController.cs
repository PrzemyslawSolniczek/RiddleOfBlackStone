using ChooseYourAdventure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Controller
{
    internal class GameController
    {
        private Scene currentScene; // aktualnie wyswietlana scena

        // konstruktor ustawia pierwsza scene gry
        public GameController()
        {
            currentScene = StoryInitializer.InitializeStory();
        }

        // rozpoczyna gre od poczatkowej sceny
        public void StartGame()
        {
            // glowna petla gry wykonuje sie dopoki jest jakas scena do wyswietlenia
            while (currentScene != null)
            {
                DisplayScene(); // wyswietla opis aktualnej sceny oraz dostepne wybory

                // jezeli jestesmy w scenie koncowej (brak dostepnych wyborow)
                if (currentScene.Choices.Count == 0)
                {
                    Console.WriteLine("\nNaciśnij dowolny klawisz, aby powrócić do menu głównego...");
                    Console.ReadKey();
                    return; // zamyka gre
                }

                // pobiera wybor gracza
                var choiceIndex = GetPlayerChoice();
                // przechodzi do nastepnej sceny na podstawie dokonanego wyboru
                currentScene = currentScene.Choices[choiceIndex].NextScene;
            }
        }

        // wyswietla aktualna scene i dostepne wybory
        private void DisplayScene()
        {
            Console.Clear();

            if (currentScene.SceneColor.HasValue)  // sprawdz, czy ustawiono kolor dla sceny
            {
                Console.ForegroundColor = currentScene.SceneColor.Value;
            }
            Console.WriteLine(currentScene.Description); // wyswietla opis sceny

            Console.ResetColor();  // resetuje kolor do domyslnego

            // jezeli scena posiada ASCII art, wyswietla go
            if (!string.IsNullOrEmpty(currentScene.AsciiArt))
            {
                Console.WriteLine(currentScene.AsciiArt);
            }

            // wyswietla dostepne wybory
            for (int i = 0; i < currentScene.Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {currentScene.Choices[i].Description}");
            }
        }

        // pobiera wybor gracza z konsoli
        private int GetPlayerChoice()
        {
            int choiceIndex = 0;  // opcja wybrana w danym momencie

            while (true)  // nieskonczona petla do momentu dokonania wyboru
            {
                DisplayChoicesWithHighlight(choiceIndex);  // wyswietl dostepne wybory z podswietleniem

                var key = Console.ReadKey(true);  // odczytaj wcisniety klawisz bez wyswietlania go na konsoli

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        choiceIndex = (choiceIndex - 1 + currentScene.Choices.Count) % currentScene.Choices.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        choiceIndex = (choiceIndex + 1) % currentScene.Choices.Count;
                        break;
                    case ConsoleKey.Enter:
                        return choiceIndex;  // wyswietl wybrany tekst
                }
            }
        }

        private void DisplayChoicesWithHighlight(int choiceIndex)
        {
            // wyswietl opis sceny i ASCII art (jesli istnieje)
            Console.Clear();
            Console.WriteLine(currentScene.Description);
            if (!string.IsNullOrEmpty(currentScene.AsciiArt))
            {
                Console.WriteLine(currentScene.AsciiArt);
            }

            // wyswietl dostepne wybory z podswietleniem
            for (int i = 0; i < currentScene.Choices.Count; i++)
            {
                if (i == choiceIndex)  // jezeli to aktualnie wybrana opcja
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">> {currentScene.Choices[i].Description}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(currentScene.Choices[i].Description);
                }
            }
        }
    }
}
