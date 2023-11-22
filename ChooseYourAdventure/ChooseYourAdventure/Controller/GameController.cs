using ChooseYourAdventure.Model;
using ChooseYourAdventure.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Controller
{
    public class GameController
    {
        private IGameModel gameModel;
        private IGameView gameView;
        private IMenuModel menuModel;
        public GameController(IGameModel _gameModel, IGameView _gameView, IMenuModel _menuModel)
        {
            gameModel = _gameModel;
            gameView = _gameView;
            menuModel = _menuModel;
        }
        public void PrintingStory()
        {
            gameView.PrintingStory(gameModel.currentScene.Description);
        }
        public void StartGame()
        {
            gameView.StartGame(gameModel, menuModel);
        }
        public void Save()
        {
            gameView.Save(gameModel);
        }
        public void Load()
        {
            gameView.Load(gameModel);
        }
        public void questionView()
        {
            gameView.questionView(gameModel.choiceIndex, gameModel, gameModel.r);
        }
        public void DisplayScene()
        {
            gameView.DisplayScene(gameModel, menuModel);
        }

        public int GetPlayerChoice()
        {
            return gameView.GetPlayerChoice(gameModel);
        }
        public int questionGetChoice()
        {
            return gameView.questionGetChoice(gameModel, gameModel.r);
        }
        public void DisplayChoicesWithHighlight()
        {
            gameView.DisplayChoicesWithHighlight(gameModel.choiceIndex, gameModel);
        }
    }
}
