using ChooseYourAdventure.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Controller
{
    [Serializable]
    public class AppState
    {
        public Scene scene { get; set; }
        public Choice choice { get; set; }
        public Player player { get; set; }
    }
}
