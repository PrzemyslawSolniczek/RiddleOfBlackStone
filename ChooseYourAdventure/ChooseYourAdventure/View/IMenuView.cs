using ChooseYourAdventure.Controller;
using ChooseYourAdventure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.View
{
    public interface IMenuView
    {
        void ShowMenu(IMenuModel mnu);
        void NewGame(GameController gameController);
        //Savy działają w ten sposób, że po prostu przy każdym wyjściu z gry, klikasz "wczytaj gre" i jak dasz "nowa gra" to ci się
        //załaduje stary save
        void LoadGame(GameController gameController);
        void About();
        void OptionsPanel(IMenuModel mn);
        void PlayMusic(SoundPlayer player, IMenuModel mn);
    }
}
