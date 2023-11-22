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
        List<Question> quiz { get; set; }
        AppState appState { get; set; }
        bool isLoaded { get; set; }
        int sum { get; set; }
        int choiceIndex { get; set; }
        Enemies skeleton { get; set; }
        Enemies dragon { get; set; }
        Player player { get; set; }
        int r { get; set; }

        /*
        bool endOfGame = false;
        int userChoice = 0;
    */
    }
}
