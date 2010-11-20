using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schmup.XnaGame.Common;

namespace Schmup.XnaGame.Sprites
{
    public class Ship : Sprite
    {
        public Ship(SchmupGame game)
            : base(game)
        {
            Velocity = new Vector2(5);
        }

        #region Sprite Members

        public override void Load()
        {
            Texture = Game.Content.Load<Texture2D>("Textures/Game/Ship");
        }

        public override void Update(GameTime gameTime)
        {
            InputState input = Game.InputState;
            Vector2 position = Position;
            if (input.MoveLeft)
                position.X -= Velocity.X;
            if (input.MoveRight)
                position.X += Velocity.X;
            if (input.MoveUp)
                position.Y -= Velocity.Y;
            if (input.MoveDown)
                position.Y += Velocity.Y;
            position.X = MathHelper.Clamp(position.X, 0, 640 - Texture.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, 720 - Texture.Height);
            Position = position;
        }

        #endregion
    }
}
