using ChooseYourAdventure.Controller;
using ChooseYourAdventure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.View
{
    public interface IGameView
    {
        void StartGame(IGameModel emp);
        void PrintingStory(string text);
        void Save(IGameModel emp);
        Scene Load(IGameModel emp);
        void questionView(int choiceIndex, IGameModel emp);
        int questionGetChoice(IGameModel emp);
        void DisplayScene(IGameModel emp);
        int GetPlayerChoice(IGameModel emp);
        void DisplayChoicesWithHighlight(int choiceIndex, IGameModel emp);
    }
}
