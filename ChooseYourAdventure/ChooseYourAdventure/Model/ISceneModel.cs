using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Model
{
    interface ISceneModel
    {
        string Description { get; set; } 
        string AsciiArt { get; set; }    // grafika ASCII -> TODO, nie ma co tego zapisywać w stringu imo, po prostu można to przekazać jako typ object -> 
        List<Choice> Choices { get; set; } // dostepne wybory dla konkretnej sceny
        ConsoleColor? SceneColor { get; set; } // bedzie ustawiany dla zakonczen
        Scene Scene { get; set; }
    }
}
