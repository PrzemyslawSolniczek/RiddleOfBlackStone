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
        public GameController(IGameModel _gameModel, IGameView _gameView)
        {
            gameModel = _gameModel;
            gameView = _gameView;
        }
        public void PrintingStory()
        {
            gameView.PrintingStory(gameModel.currentScene.Description);
        }
        public void StartGame()
        {
            gameView.StartGame(gameModel);
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
            gameView.questionView(gameModel.choiceIndex, gameModel);
        }
        public void DisplayScene()
        {
            gameView.DisplayScene(gameModel);
        }

        public int GetPlayerChoice()
        {
            return gameView.GetPlayerChoice(gameModel);
        }
        public int questionGetChoice()
        {
            return gameView.questionGetChoice(gameModel);
        }
        public void DisplayChoicesWithHighlight()
        {
            gameView.DisplayChoicesWithHighlight(gameModel.choiceIndex, gameModel);
        }
    }
}
