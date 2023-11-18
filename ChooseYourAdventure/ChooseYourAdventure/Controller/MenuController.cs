using ChooseYourAdventure.Model;
using ChooseYourAdventure.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Controller
{
    public class MenuController
    {
        private IMenuView menuView;
        private IMenuModel menuModel;
        public MenuController(IMenuView _menuView, IMenuModel _menuModel) 
        {
            menuView = _menuView;
            menuModel = _menuModel;
        }
        public void ShowMenu()
        {
            menuView.ShowMenu(menuModel);
        }
        public void NewGame(GameController gameController)
        {
            menuView.NewGame(gameController); //do sprawdzenia
        }
        public void LoadGame(GameController gameController)
        {
            menuView.LoadGame(gameController);
        }
        public void About()
        {
            menuView.About();
        }
        public void OptionsPanel()
        {
            menuView.OptionsPanel(menuModel);
        }
        public void PlayMusic()
        {
            menuView.PlayMusic(menuModel.SoundPlayer, menuModel);
        }
    }
}
