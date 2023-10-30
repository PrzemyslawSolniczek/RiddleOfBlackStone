﻿using ChooseYourAdventure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            // ekran ladowania
   //         DisplayLoadingAnimation();

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

            if (Program.DisplayTextLetterByLetter)
            {
                foreach (char l in currentScene.Description)
                {
                    Console.Write(l);
                    Thread.Sleep(50); // czekaj 50ms między literami
                }
                Console.WriteLine(); // Nowa linia po wyświetleniu całego opisu
            }
            else
            {
                Console.WriteLine(currentScene.Description); // wyswietla opis sceny od razu
            }

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

        private void DisplayLoadingAnimation()
        {
            Console.Clear();
            Console.WriteLine("Gra jest ładowana...\n");

            string[] frames =
            {
                "~    ~    ~\n" +
                "  ~    ~    ~\n" +
                "~    ~    ~",

                "  ~    ~    ~\n" +
                "~    ~    ~\n" +
                "  ~    ~    ~"
            };

            int durationInSeconds = 10;
            int delayInMillis = 500;  // czestotliwosc zmiany animacji

            int totalIterations = (durationInSeconds * 1000) / delayInMillis;

            for (int i = 0; i < totalIterations; i++)
            {
                Console.SetCursorPosition(0, 1);  // resetuje kursor do początkowej pozycji
                Console.Write(frames[i % frames.Length]);
                System.Threading.Thread.Sleep(delayInMillis);
            }

            Console.SetCursorPosition(0, 4);
            Console.Clear();
            Console.WriteLine("Ładowanie zakończone!");
            Thread.Sleep(1000);
        }
    }
}
