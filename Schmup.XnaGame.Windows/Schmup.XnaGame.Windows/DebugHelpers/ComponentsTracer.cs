using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schmup.XnaGame.DebugHelpers
{
    public class ComponentsTracer : DrawableGameComponent
    {
        private Vector2 bottomPosition;
        private Dictionary<string, GameComponent> gameComponents = new Dictionary<string, GameComponent>();
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private List<string> statesList = new List<string>();

        public ComponentsTracer(SchmupGame game)
            : base(game)
        {
        }

        public void AddComponent(string title, GameComponent component)
        {
            gameComponents.Add(title, component);
        }

        #region DrawableGameComponent Members

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            spriteFont = Game.Content.Load<SpriteFont>("Fonts/ComponentsTracer");
            bottomPosition = new Vector2(Game.Window.ClientBounds.Width - 200,
                                         Game.Window.ClientBounds.Height - spriteFont.LineSpacing);
        }

        public override void Update(GameTime gameTime)
        {
            statesList.Clear();
            foreach (var item in gameComponents)
            {
                bool enabled = item.Value.Enabled;
                bool visible = false;
                DrawableGameComponent drawable = item.Value as DrawableGameComponent;
                if (drawable != null && drawable.Visible)
                    visible = true;
                statesList.Add((enabled ? "E" : " ") + "|" + (visible ? "V" : " ") + " " + item.Key);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 position = bottomPosition;
            spriteBatch.Begin();
            foreach (var state in statesList)
            {
                spriteBatch.DrawString(spriteFont, state, position, Color.Gray);
                position.Y -= spriteFont.LineSpacing;
            }
            spriteBatch.End();
        }

        #endregion
    }
}
