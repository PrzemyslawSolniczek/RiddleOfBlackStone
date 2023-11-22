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
    public class SceneModel : ISceneModel
    {
        private string _description;
        private string _asciiArt;  // grafika ASCII -> TODO, nie ma co tego zapisywać w stringu imo, po prostu można to przekazać jako typ object -> 
        private List<Choice> _choices;  // dostepne wybory dla konkretnej sceny
        private ConsoleColor? _sceneColor;
        private Scene _scene;
        public SceneModel()
        {
            _choices = new List<Choice>();
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string AsciiArt
        {
            get { return _asciiArt; }
            set { _asciiArt = value; }
        }
        public List<Choice> Choices
        {
            get { return _choices; }
            set { _choices = value; }
        }
        public ConsoleColor? SceneColor
        {
            get { return _sceneColor; }
            set { _sceneColor = value; }
        }
        public Scene Scene
        {
            get { return _scene; }
            set { _scene = value; }
        }
    }
}
