using System;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schmup.XnaGame.DebugHelpers
{
    public class FrameRateCounter : DrawableGameComponent
    {
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private NumberFormatInfo format;
        private int frameCounter;
        private int frameRate;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        public FrameRateCounter(SchmupGame game)
            : base(game)
        {
            format = new NumberFormatInfo();
            format.NumberDecimalSeparator = ".";
            position = new Vector2(5, 5);
        }

        #region DrawableGameComponent Members

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            spriteFont = Game.Content.Load<SpriteFont>("Fonts/FramerateCounter");
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime <= TimeSpan.FromSeconds(1))
                return;
            elapsedTime -= TimeSpan.FromSeconds(1);
            frameRate = frameCounter;
            frameCounter = 0;
        }

        public override void Draw(GameTime gameTime)
        {
            frameCounter++;
            string fps = string.Format(format, "{0} fps", frameRate);
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, fps, position, Color.Gray);
            spriteBatch.End();
        }

        #endregion
    }
}
