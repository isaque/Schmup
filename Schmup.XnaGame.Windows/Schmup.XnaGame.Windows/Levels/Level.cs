using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schmup.XnaGame.Common;
using Schmup.XnaGame.DebugHelpers;
using Schmup.XnaGame.Sprites;

namespace Schmup.XnaGame.Levels
{
    public class Level : SchmupDrawableGameComponent
    {
        private List<Bullet> shipBullets = new List<Bullet>();
        private Ship ship;

        private SpriteBatch spriteBatch;
        private Viewport viewport;

        private Vector2 shipBulletVelocity = new Vector2(0, -10);

#if DEBUG
        private LevelTracer levelTracer;
#endif

        #region Properties for the LevelTracer

        public int ShipBulletsCount
        {
            get { return shipBullets.Count; }
        }

        #endregion

        public Level(SchmupGame game)
            : base(game)
        {
            this.Enabled = this.Visible = false;
#if DEBUG
            levelTracer = new LevelTracer(game, this);
#endif
        }

        #region SchmupDrawableGameComponent Members

        public override void Initialize()
        {
            viewport = new Viewport(320, 0, 640, 720);
            ship = new Ship(SchmupGame);
            ship.Position = new Vector2(280, 600);
#if DEBUG
            levelTracer.Initialize();
#endif
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            ship.Load();
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

            ship.Update(gameTime);
            shipBullets.ForEach(sprite => sprite.Update(gameTime));
            if (input.ShootBullet)
                AddBullet(shipBullets, new Bullet(SchmupGame, new Vector2(ship.Bounds.Center.X, ship.Position.Y), shipBulletVelocity, "Textures/Game/Ship/Bullet"));
            RemoveAllOutOfScreenBullets();
#if DEBUG
            levelTracer.Update(gameTime);
#endif
        }

        public override void Draw(GameTime gameTime)
        {
            Viewport oldViewport = GraphicsDevice.Viewport;
            GraphicsDevice.Viewport = viewport;
            spriteBatch.Begin();
            spriteBatch.Draw(ship.Texture, ship.Position, Color.White);
            shipBullets.ForEach(sprite => spriteBatch.Draw(sprite.Texture, sprite.Position, Color.White));
            spriteBatch.End();
            GraphicsDevice.Viewport = oldViewport;
#if DEBUG
            levelTracer.Draw(gameTime);
#endif
        }

        #endregion

        private void AddBullet(List<Bullet> bulletList, Bullet bullet)
        {
            bullet.Load();
            bulletList.Add(bullet);
        }

        private void RemoveAllOutOfScreenBullets()
        {
            RemoveAllOutOfScreenBullets(shipBullets);
        }

        private void RemoveAllOutOfScreenBullets(List<Bullet> bulletList)
        {
            Rectangle bounds = new Rectangle(0, 0, viewport.Width, viewport.Height);
            for (int i = 0; i < bulletList.Count; ++i)
            {
                Bullet bullet = bulletList[i];
                if (!bullet.Bounds.Intersects(bounds))
                {
                    bulletList.Remove(bullet);
                    --i;
                }
            }
        }
    }
}
