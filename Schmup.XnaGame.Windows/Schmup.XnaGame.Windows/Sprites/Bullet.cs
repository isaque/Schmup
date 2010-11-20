using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schmup.XnaGame.Sprites
{
    public class Bullet : Sprite
    {
        private string bulletTexturePath;

        public Bullet(SchmupGame game, Vector2 position, Vector2 velocity, string bulletTexturePath)
            : base(game)
        {
            Position = position;
            Velocity = velocity;
            this.bulletTexturePath = bulletTexturePath;
        }

        #region Sprite Members

        public override void Load()
        {
            Texture = Game.Content.Load<Texture2D>(bulletTexturePath);
            Position = new Vector2(Position.X - (Texture.Width / 2), Position.Y - Texture.Height);
        }

        #endregion
    }
}
