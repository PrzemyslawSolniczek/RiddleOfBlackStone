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
        void StartGame(IGameModel emp, IMenuModel mn);
        void PrintingStory(string text);
        void Save(IGameModel emp);
        Scene Load(IGameModel emp);
        void questionView(int choiceIndex, IGameModel emp, int random);
        int questionGetChoice(IGameModel emp, int r);
        void DisplayScene(IGameModel emp, IMenuModel mn);
        int GetPlayerChoice(IGameModel emp);
        void DisplayChoicesWithHighlight(int choiceIndex, IGameModel emp);
    }
}
