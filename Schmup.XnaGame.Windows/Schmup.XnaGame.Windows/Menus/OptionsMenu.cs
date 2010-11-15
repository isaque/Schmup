namespace Schmup.XnaGame.Menus
{
    public class OptionsMenu : Menu
    {
        private const int backMenuItemIndex = 0;

        public OptionsMenu(SchmupGame game)
            : base(game)
        {
            MenuEntry menuEntry;
            menuEntry = new MenuEntry("Back to main menu");
            AddEntry(menuEntry);
            this.Enabled = this.Visible = false;
        }

        #region Menu Members

        protected override void OnSelectedEntry(int selectedEntryIndex)
        {
            if (selectedEntryIndex == backMenuItemIndex)
            {
                SchmupGame.MainMenu.Enabled = SchmupGame.MainMenu.Visible = true;
                this.Enabled = this.Visible = false;
            }
        }

        #endregion
    }
}
