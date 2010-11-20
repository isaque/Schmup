using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schmup.XnaGame.Common;
using Schmup.XnaGame.Sprites;

namespace Schmup.XnaGame.Levels
{
    public class Level : SchmupDrawableGameComponent
    {
        private List<Sprite> sprites;
        private Ship ship;

        private SpriteBatch spriteBatch;
        private Viewport viewport;

        public Level(SchmupGame game)
            : base(game)
        {
            this.Enabled = this.Visible = false;
            sprites = new List<Sprite>();
        }

        #region SchmupDrawableGameComponent Members

        public override void Initialize()
        {
            viewport = new Viewport(320, 0, 640, 720);
            ship = new Ship(SchmupGame);
            ship.Position = new Vector2(280, 600);
            sprites.Add(ship);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            sprites.ForEach(sprite => sprite.Load());
        }

        public override void Update(GameTime gameTime)
        {
            InputState input = SchmupGame.InputState;
            if (input.PauseGame)
            {
                SchmupGame.MainMenu.Enabled = SchmupGame.MainMenu.Visible = true;
                SchmupGame.ScoreManager.Enabled = SchmupGame.ScoreManager.Visible = false;
                this.Enabled = this.Visible = false;
                return;
            }

            sprites.ForEach(sprite => sprite.Update(gameTime));
        }

        public override void Draw(GameTime gameTime)
        {
            Viewport oldViewport = GraphicsDevice.Viewport;
            GraphicsDevice.Viewport = viewport;
            spriteBatch.Begin();
            sprites.ForEach(sprite => spriteBatch.Draw(sprite.Texture, sprite.Position, Color.White));
            spriteBatch.End();
            GraphicsDevice.Viewport = oldViewport;
        }

        #endregion
    }
}
