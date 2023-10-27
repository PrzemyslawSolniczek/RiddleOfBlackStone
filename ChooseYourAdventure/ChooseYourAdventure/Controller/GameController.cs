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
            Console.WriteLine(currentScene.Description); // wyswietla opis sceny

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
            int choice = -1;

            // petla wykonywana dopoki gracz nie poda prawidlowego wyboru
            while (choice < 0 || choice >= currentScene.Choices.Count)
            {
                Console.Write("Wybierz opcję: ");
                int.TryParse(Console.ReadLine(), out choice);
                choice--; // odejmujemy 1, poniewaz lista wyborow zaczyna sie od indeksu 0
            }

            return choice; // zwraca indeks wyboru
        }
    }
}
