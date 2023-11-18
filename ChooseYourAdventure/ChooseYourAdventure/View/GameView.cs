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
        public int questionGetChoice(IGameModel emp)
        {
            int choiceIndex = 0;  // opcja wybrana w danym momencie
            int i = 15;
            while (true)  // nieskonczona petla do momentu dokonania wyboru
            {
                questionView(choiceIndex, emp);
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        choiceIndex = (choiceIndex - 1 + emp.quiz.Answers.Count) % emp.quiz.Answers.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        choiceIndex = (choiceIndex + 1) % emp.quiz.Answers.Count;
                        break;
                    case ConsoleKey.Enter:
                        return choiceIndex;  // wyswietl wybrany tekst
                }

            }
        }
        public void DisplayScene(IGameModel emp)
        {
            emp.sum++;
            if (emp.sum == 2)
            {
                PrintingAscii.DrawCave();
                PrintingAscii.DrawSkeleton();
                emp.skeleton.attack = 1;
                emp.skeleton.live = 1;
                //System.Timers.Timer aTimer = new System.Timers.Timer();
                //aTimer.Elapsed += new System.Timers.ElapsedEventHandler(skeletonAttack);
                //aTimer.Interval = 500000;
                int i;
                var choice = questionGetChoice(emp);
                //aTimer.Start();
                if (emp.quiz.Answers[choice].correctAnswer)
                {
                    //  aTimer.Dispose();
                    Console.WriteLine("Udało ci się");
                }
                else
                {
                    emp.player.Lives -= emp.skeleton.attack;
                }
                //Thread.Sleep(2000);
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
            /*
            if (isScene1)
            {
                PrintingAscii.DrawStone();
                isScene1 = false;
            }
            else
            {
                Console.Clear();
            }
            */
            //Console.SetCursorPosition(0, 29);
            if (emp.currentScene.SceneColor.HasValue)  // sprawdz, czy ustawiono kolor dla sceny
            {
                Console.ForegroundColor = emp.currentScene.SceneColor.Value;
            }
            PrintingStory(emp.currentScene.Description);
            Console.WriteLine(); 

            
            Console.ResetColor();  // resetuje kolor do domyslnego

            // jezeli scena posiada ASCII art, wyswietla go

            // wyswietla dostepne wybory
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
        public void StartGame(IGameModel emp)
        {
            //string lives = string.Format("Życia: {0}", emp.player.Lives).PadLeft(3, '0');
            while (emp.currentScene != null)
            {
                PrintingAscii.DrawAt(105, 0, "Życia: ", ConsoleColor.DarkYellow);
                PrintingAscii.DrawLineAtH(113, 0, (emp.player.Lives).ToString().Length, emp.player.Lives, ConsoleColor.DarkYellow);
                DisplayScene(emp); // wyswietla opis aktualnej sceny oraz dostepne wybory

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
        public void questionView(int choiceIndex, IGameModel emp)
        {
            Console.Clear();
            PrintingAscii.DrawAt(105, 0, "Życia: ", ConsoleColor.DarkYellow);
            PrintingAscii.DrawLineAtH(113, 0, (emp.player.Lives).ToString().Length, emp.player.Lives, ConsoleColor.DarkYellow);
            PrintingAscii.DrawSkeleton();
            Console.WriteLine("\n");
            Console.WriteLine("UWAGA PYTANIE " + emp.quiz.Description);
            for (int i = 0; i < emp.quiz.Answers.Count; i++)
            {
                if (i == choiceIndex)  // jezeli to aktualnie wybrana opcja
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">> {emp.quiz.Answers[i].Description}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(emp.quiz.Answers[i].Description);
                }
            }
        }

    }
}
