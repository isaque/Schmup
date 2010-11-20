using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schmup.XnaGame.Levels;

namespace Schmup.XnaGame.DebugHelpers
{
    public class LevelTracer : DrawableGameComponent
    {
        private Level level;

        private SpriteFont font;
        private SpriteBatch spriteBatch;

        public LevelTracer(Game game, Level level)
            : base(game)
        {
            this.level = level;
        }

        #region DrawableGameComponent

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            font = Game.Content.Load<SpriteFont>("Fonts/LevelTracer");
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 position = new Vector2(0, Game.GraphicsDevice.Viewport.Height - font.LineSpacing);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Ship's bullets : " + level.ShipBulletsCount, position, Color.Gray);
            spriteBatch.End();
        }

        #endregion
    }
}
