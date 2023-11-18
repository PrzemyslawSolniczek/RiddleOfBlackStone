using ChooseYourAdventure.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Model
{
    public interface IGameModel
    {
        Scene currentScene { get; set; }
        Question quiz { get; set; }
        AppState appState { get; set; }
        bool isLoaded { get; set; }
        int sum { get; set; }
        int choiceIndex { get; set; }
        Enemies skeleton { get; set; }
        Player player { get; set; }

        /*
        bool endOfGame = false;
        int userChoice = 0;
    */
    }
}
