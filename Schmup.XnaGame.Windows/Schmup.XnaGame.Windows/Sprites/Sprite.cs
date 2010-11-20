using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schmup.XnaGame.Sprites
{
    public abstract class Sprite
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; protected set; }
        public Vector2 Velocity { get; set; }

        protected SchmupGame Game { get; private set; }

        public Sprite(SchmupGame game)
        {
            Game = game;
        }

        public abstract void Load();

        public virtual void Update(GameTime gameTime)
        {
            if (Velocity != Vector2.Zero)
                Position += Velocity;
        }
    }
}
