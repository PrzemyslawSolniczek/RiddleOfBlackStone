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
        void NewGame(GameController gameController, IMenuModel mn);
        void LoadGame(GameController gameController, IMenuModel mn);
        void About();
        void OptionsPanel(IMenuModel mn);
        void PlayMusic(SoundPlayer player, IMenuModel mn);
    }
}
