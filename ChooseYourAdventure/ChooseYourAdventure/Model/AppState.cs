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
        public Scene Scene { get; set; }
        public int Lives { get; set; }
        public int sum { get; set; }
    }
}
