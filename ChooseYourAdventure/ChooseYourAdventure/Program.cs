using ChooseYourAdventure.Controller;
using ChooseYourAdventure.Model;
using ChooseYourAdventure.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMenuModel menuModel = new MenuModel();
            IMenuView menuView = new MenuView();
            MenuController menuController = new MenuController(menuView, menuModel);
            IGameView gameView = new GameView();
            IGameModel gameModel = new GameModel();
            gameModel.currentScene = StoryInitializer.InitializeStory();
            menuModel.Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sound\WelcomeScreen.wav";
            menuModel.SoundPlayer.SoundLocation = menuModel.Path;
            menuModel.SoundPlayer.Play();
            //PrintingAscii.WelcomeScreen();
            Console.Clear();
            Thread.Sleep(2000);
            while (!menuModel.EndOfGame)
            {
                gameModel.currentScene = StoryInitializer.InitializeStory();
                GameController gameController = new GameController(gameModel, gameView);
                menuController.ShowMenu();

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        // dodajemy 4, aby zapewnic, ze wartosc jest dodatnia
                        menuModel.UserChoice = (menuModel.UserChoice - 1 + 5) % 5;
                        break;
                    case ConsoleKey.DownArrow:
                        menuModel.UserChoice = (menuModel.UserChoice + 1) % 5;
                        break;
                    case ConsoleKey.Enter:
                        switch (menuModel.UserChoice)
                        {
                            case 0:
                                menuController.NewGame(gameController);
                                break;
                            case 1:
                                menuController.LoadGame(gameController);
                                break;
                            case 2:
                                menuController.About();
                                break;
                            case 3:
                                menuController.OptionsPanel();
                                break;
                            case 4:
                                menuModel.EndOfGame = true;
                                break;
                        }
                        break;
                }
            }
        }
    }
}

