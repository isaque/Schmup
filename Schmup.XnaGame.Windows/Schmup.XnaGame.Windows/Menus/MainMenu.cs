using Microsoft.Xna.Framework;

namespace Schmup.XnaGame.Menus
{
    public class MainMenu : Menu
    {
        private const int optionsMenuItemIndex = 1;
        private const int exitMenuItemIndex = 2;

        public MainMenu(SchmupGame game)
            : base(game)
        {
            MenuEntry menuEntry;
            menuEntry = new MenuEntry("Start");
            AddEntry(menuEntry);
            menuEntry = new MenuEntry("Options");
            AddEntry(menuEntry);
            menuEntry = new MenuEntry("Exit");
            AddEntry(menuEntry);
        }

        #region Menu Members

        protected override void OnSelectedEntry(int selectedEntryIndex)
        {
            switch (selectedEntryIndex)
            {
                case optionsMenuItemIndex:
                    SchmupGame.OptionsMenu.Enabled = SchmupGame.OptionsMenu.Visible = true;
                    this.Enabled = this.Visible = false;
                    break;
                case exitMenuItemIndex:
                    Game.Exit();
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
