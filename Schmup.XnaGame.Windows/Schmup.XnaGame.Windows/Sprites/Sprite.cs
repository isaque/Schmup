using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schmup.XnaGame.Sprites
{
    public abstract class Sprite
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; protected set; }
        public Vector2 Velocity { get; set; }

        public Rectangle Bounds { get; protected set; }
        public Rectangle CollisonMask { get; protected set; }

        protected SchmupGame Game { get; private set; }

        public Sprite(SchmupGame game)
        {
            Game = game;
            Bounds = new Rectangle(0, 0, 1, 1);
        }

        public abstract void Load();

        public virtual void Update(GameTime gameTime)
        {
            if (Velocity != Vector2.Zero)
                Position += Velocity;

            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }
    }
}
