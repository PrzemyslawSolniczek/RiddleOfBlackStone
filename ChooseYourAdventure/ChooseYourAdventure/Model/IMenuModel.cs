using ChooseYourAdventure.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Model
{
    public interface IMenuModel
    {
        bool DisplayTextLetterByLetter { get; set; }
        bool Music { get; set; }
        string Path  { get; set; } 
        bool Check { get; set; }
        SoundPlayer SoundPlayer { get; set; }
        AppState AppState { get; set; }
        bool EndOfGame { get; set; }
        int UserChoice { get; set; }
    }
}
