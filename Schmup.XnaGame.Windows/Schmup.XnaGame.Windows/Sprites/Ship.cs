using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schmup.XnaGame.Common;

namespace Schmup.XnaGame.Sprites
{
    public class Ship : Sprite
    {
        private Vector2 ControlledVelocity = new Vector2(5);

        public Ship(SchmupGame game)
            : base(game)
        {
        }

        #region Sprite Members

        public override void Load()
        {
            Texture = Game.Content.Load<Texture2D>("Textures/Game/Ship/Ship");
        }

        public override void Update(GameTime gameTime)
        {
            InputState input = Game.InputState;
            Vector2 position = Position;
            if (input.MoveLeft)
                position.X -= ControlledVelocity.X;
            if (input.MoveRight)
                position.X += ControlledVelocity.X;
            if (input.MoveUp)
                position.Y -= ControlledVelocity.Y;
            if (input.MoveDown)
                position.Y += ControlledVelocity.Y;
            position.X = MathHelper.Clamp(position.X, 0, 640 - Texture.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, 720 - Texture.Height);
            Position = position;
            base.Update(gameTime);
        }

        #endregion
    }
}
