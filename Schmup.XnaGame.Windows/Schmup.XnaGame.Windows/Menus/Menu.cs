using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schmup.XnaGame.Common;

namespace Schmup.XnaGame.Menus
{
    public abstract class Menu : SchmupDrawableGameComponent
    {
        public Vector2 MenuTopPosition { get; protected set; }

        private SpriteFont menuFont;
        private List<MenuEntry> menuEntries = new List<MenuEntry>();
        private int selectedEntryIndex = 0;
        private SpriteBatch spriteBatch;

        public Menu(SchmupGame game)
            : base(game)
        {
            MenuTopPosition = new Vector2(100, 300);
        }

        protected void AddEntry(MenuEntry menuEntry)
        {
            menuEntries.Add(menuEntry);
        }

        protected abstract void OnSelectedEntry(int selectedEntryIndex);

        #region SchmupDrawableGameComponent Members

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            menuFont = Game.Content.Load<SpriteFont>("Fonts/Menu");
        }

        public override void Update(GameTime gameTime)
        {
            InputState input = SchmupGame.InputState;
            if (input.MenuUp)
            {
                selectedEntryIndex--;
                if (selectedEntryIndex < 0)
                    selectedEntryIndex = menuEntries.Count - 1;
            }
            if (input.MenuDown)
            {
                selectedEntryIndex++;
                if (selectedEntryIndex >= menuEntries.Count)
                    selectedEntryIndex = 0;
            }
            if (input.MenuSelect)
            {
                OnSelectedEntry(selectedEntryIndex);
                // If the input is not updated, the first item of the following menu is immediately selected
                input.Update();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 position = MenuTopPosition;
            int delta = menuFont.LineSpacing;
            spriteBatch.Begin();
            int i = 0;
            foreach (MenuEntry menuEntry in menuEntries)
            {
                Color color = Color.White;
                if (i == selectedEntryIndex)
                    color = Color.Red;
                spriteBatch.DrawString(menuFont, menuEntry.Title, position, color);
                position.Y += delta;
                ++i;
            }
            spriteBatch.End();
        }

        #endregion
    }
}
