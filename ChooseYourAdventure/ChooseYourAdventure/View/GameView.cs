using ChooseYourAdventure.Controller;
using ChooseYourAdventure.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChooseYourAdventure.View
{
    public class GameView : IGameView
    {
        public void PrintingStory(string text)
        {
            bool skip = false;
            while (!Console.KeyAvailable && !skip)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (Console.KeyAvailable)
                    {
                        skip = true;
                        break;
                    }

                    Console.Write(text[i]);
                    Thread.Sleep(30);
                }
                break;
            }
            if (skip)
            {
                Console.WriteLine(text);
            }

            Console.WriteLine();
        }
        public int questionGetChoice(IGameModel emp, int r)
        {
            Random rnd = new Random();
            Question question = new Question();
            int choiceIndex = 0;  // opcja wybrana w danym momencie
            int i = 15;
            while (true)  // nieskonczona petla do momentu dokonania wyboru
            {
                questionView(choiceIndex, emp, r);
                question = emp.quiz[r];
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        choiceIndex = (choiceIndex - 1 + question.Answers.Count) % question.Answers.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        choiceIndex = (choiceIndex + 1) % question.Answers.Count;
                        break;
                    case ConsoleKey.Enter:
                        return choiceIndex;  // wyswietl wybrany tekst
                }

            }
        }
        public void DisplayScene(IGameModel emp, IMenuModel mn)
        {

            emp.sum++; 
            if (emp.sum == 2)
            {
                //PrintingAscii.DrawCave();
                PrintingAscii.DrawSkeleton();
                emp.skeleton.attack = 1;
                emp.skeleton.live = 1;
                int i;
                Random rnd = new Random();
                int r = rnd.Next(emp.quiz.Count);
                Question question = new Question();
                var choice = questionGetChoice(emp, r);
                question = emp.quiz[r];
                //aTimer.Start();
                if (question.Answers[choice].correctAnswer)
                {
                    Console.Clear();
                    PrintingAscii.CorrectAnswer();
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    PrintingAscii.IncorrectAnswer();
                    Console.ReadKey();
                    emp.player.Lives -= emp.skeleton.attack;
                }
                if (emp.player.Lives == 0)
                {
                    Console.Clear();
                    PrintingAscii.GameOver();
                    Thread.Sleep(2000);
                    emp.player.Lives = 3;
                    emp.sum = 0;
                    emp.currentScene = StoryInitializer.InitializeStory(); //TODO DO SPRAWDZENIA
                    Console.ReadKey();
                }
            }
            if(emp.sum == 4)
            {
                PrintingAscii.DrawDragon();
                Random rnd = new Random();
                int r = rnd.Next(emp.quiz.Count);
                Question question = new Question();
                var choice = questionGetChoice(emp, r);
                question = emp.quiz[r];
                if (question.Answers[choice].correctAnswer)
                {
                    Console.Clear();
                    PrintingAscii.CorrectAnswer();
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    PrintingAscii.IncorrectAnswer();
                    Console.ReadKey();
                    emp.player.Lives -= emp.dragon.attack;
                }
                if (emp.player.Lives == 0)
                {
                    Console.Clear();
                    PrintingAscii.GameOver();
                    Thread.Sleep(2000);
                    emp.player.Lives = 3;
                    emp.sum = 0;
                    emp.currentScene = StoryInitializer.InitializeStory(); //TODO DO SPRAWDZENIA
                    Console.ReadKey();
                }

            }
            Console.Clear();
            if (emp.isLoaded)
            {
                emp.currentScene = Load(emp);
                emp.isLoaded = false;
            }

            PrintingAscii.DrawAt(105, 0, "Życia: ", ConsoleColor.DarkYellow);
            PrintingAscii.DrawLineAtH(113, 0, (emp.player.Lives).ToString().Length, emp.player.Lives, ConsoleColor.DarkYellow);
            if (!string.IsNullOrEmpty(emp.currentScene.AsciiArt))
            {
                Console.WriteLine(emp.currentScene.AsciiArt);
            }
            if (emp.currentScene.SceneColor.HasValue)  // sprawdz, czy ustawiono kolor dla sceny
            {
                Console.ForegroundColor = emp.currentScene.SceneColor.Value;
            }
            if (mn.DisplayTextLetterByLetter)
            {
                PrintingStory(emp.currentScene.Description);
            }
            Console.WriteLine(emp.currentScene.Description);
            Console.WriteLine(); 
;
            
            Console.ResetColor();  // resetuje kolor do domyslnego

            for (int i = 0; i < emp.currentScene.Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {emp.currentScene.Choices[i].Description}");
            }
            Save(emp);
        }
        public int GetPlayerChoice(IGameModel emp)
        {
            emp.choiceIndex = 0;  // opcja wybrana w danym momencie

            while (true)  // nieskonczona petla do momentu dokonania wyboru
            {
                DisplayChoicesWithHighlight(emp.choiceIndex, emp);  // wyswietl dostepne wybory z podswietleniem

                var key = Console.ReadKey(true);  // odczytaj wcisniety klawisz bez wyswietlania go na konsoli

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        emp.choiceIndex = (emp.choiceIndex - 1 + emp.currentScene.Choices.Count) % emp.currentScene.Choices.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        emp.choiceIndex = (emp.choiceIndex + 1) % emp.currentScene.Choices.Count;
                        break;
                    case ConsoleKey.Enter:
                        return emp.choiceIndex;  // wyswietl wybrany tekst
                }
            }
        }
        public void DisplayChoicesWithHighlight(int choiceIndex, IGameModel emp)
        {
            Console.Clear();
            PrintingAscii.DrawAt(105, 0, "Życia: ", ConsoleColor.DarkYellow);
            PrintingAscii.DrawLineAtH(113, 0, (emp.player.Lives).ToString().Length, emp.player.Lives, ConsoleColor.DarkYellow);
            if (!string.IsNullOrEmpty(emp.currentScene.AsciiArt))
            {
                Console.WriteLine(emp.currentScene.AsciiArt);
            }
            if (emp.currentScene.SceneColor.HasValue)  // sprawdz, czy ustawiono kolor dla sceny
            {
                Console.ForegroundColor = emp.currentScene.SceneColor.Value;
            }
            Console.WriteLine(emp.currentScene.Description);

            // wyswietl dostepne wybory z podswietleniem
            for (int i = 0; i < emp.currentScene.Choices.Count; i++)
            {
                if (i == choiceIndex)  // jezeli to aktualnie wybrana opcja
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">> {emp.currentScene.Choices[i].Description}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(emp.currentScene.Choices[i].Description);
                }
            }
        }
        public void StartGame(IGameModel emp, IMenuModel mn)
        {
            emp.sum = 0;
            emp.player.Lives = 3;
            while (emp.currentScene != null)
            {
                PrintingAscii.DrawAt(105, 0, "Życia: ", ConsoleColor.DarkYellow);
                PrintingAscii.DrawLineAtH(113, 0, (emp.player.Lives).ToString().Length, emp.player.Lives, ConsoleColor.DarkYellow);
                DisplayScene(emp, mn); // wyswietla opis aktualnej sceny oraz dostepne wybory

                // jezeli jestesmy w scenie koncowej (brak dostepnych wyborow)
                if (emp.currentScene.Choices.Count == 0)
                {
                    Console.WriteLine("\nNaciśnij dowolny klawisz, aby powrócić do menu głównego...");
                    Console.ReadKey();
                    return; // zamyka gre
                }

                // pobiera wybor gracza
                var choiceIndex = GetPlayerChoice(emp);
                Console.Clear();
                // przechodzi do nastepnej sceny na podstawie dokonanego wyboru
                emp.currentScene = emp.currentScene.Choices[choiceIndex].NextScene;
            }
        }
        public void Save(IGameModel emp)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(emp.currentScene.GetType());
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter output = new StreamWriter(Path.Combine(docPath, "save.xml")))
            {
                x.Serialize(output, emp.currentScene);
            }
        }
        public Scene Load(IGameModel emp)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(emp.currentScene.GetType());
            emp.isLoaded = true;
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(docPath, "save.xml");
            if (File.Exists(filePath))
            {
                using (StreamReader output = new StreamReader(filePath))
                {
                    var loadedScene = x.Deserialize(output);
                    emp.currentScene = (Scene)loadedScene;
                }
            }
            return emp.currentScene;
        }
        public void questionView(int choiceIndex, IGameModel emp, int random)
        {
            Console.Clear();
            PrintingAscii.DrawAt(105, 0, "Życia: ", ConsoleColor.DarkYellow);
            PrintingAscii.DrawLineAtH(113, 0, (emp.player.Lives).ToString().Length, emp.player.Lives, ConsoleColor.DarkYellow);
            if(emp.sum == 2)
                PrintingAscii.DrawSkeleton();
            else if(emp.sum == 4)
                PrintingAscii.DrawDragon();
            Console.WriteLine("\n\n");
            Question question = new Question();
            PrintingAscii.DrawAt(1, 15, "UWAGA: " + emp.quiz[random].Description, ConsoleColor.DarkYellow);
            Console.WriteLine("\n");
            question = emp.quiz[random];
            for (int i = 0; i < question.Answers.Count; i++)
            {
                if (i == choiceIndex)  // jezeli to aktualnie wybrana opcja
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">> {question.Answers[i].Description}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(question.Answers[i].Description);
                }
            }
        }

    }
}
