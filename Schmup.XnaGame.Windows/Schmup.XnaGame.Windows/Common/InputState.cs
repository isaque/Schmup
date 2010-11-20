using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Schmup.XnaGame.Common
{
    public class InputState
    {
        public GamePadState CurrentGamePadState;
        public KeyboardState CurrentKeyboardState;

        public GamePadState LastGamePadState;
        public KeyboardState LastKeyboardState;

        public bool MenuUp
        {
            get
            {
                return IsNewKeyPress(Keys.Up)
                    || (CurrentGamePadState.DPad.Up == ButtonState.Pressed
                        && LastGamePadState.DPad.Up == ButtonState.Released)
                    || (CurrentGamePadState.ThumbSticks.Left.Y > 0
                        && LastGamePadState.ThumbSticks.Left.Y <= 0);
            }
        }

        public bool MenuDown
        {
            get
            {
                return IsNewKeyPress(Keys.Down)
                    || (CurrentGamePadState.DPad.Down == ButtonState.Pressed
                        && LastGamePadState.DPad.Down == ButtonState.Released)
                    || (CurrentGamePadState.ThumbSticks.Left.Y < 0
                        && LastGamePadState.ThumbSticks.Left.Y >= 0);
            }
        }

        public bool MenuSelect
        {
            get
            {
                return IsNewKeyPress(Keys.Space)
                    || IsNewKeyPress(Keys.Enter)
                    || (CurrentGamePadState.Buttons.A == ButtonState.Pressed
                        && LastGamePadState.Buttons.A == ButtonState.Released)
                    || (CurrentGamePadState.Buttons.Start == ButtonState.Pressed
                        && LastGamePadState.Buttons.Start == ButtonState.Released);
            }
        }

        public bool MenuCancel
        {
            get
            {
                return IsNewKeyPress(Keys.Escape)
                    || (CurrentGamePadState.Buttons.B == ButtonState.Pressed
                        && LastGamePadState.Buttons.B == ButtonState.Released)
                    || (CurrentGamePadState.Buttons.Back == ButtonState.Pressed
                        && LastGamePadState.Buttons.Back == ButtonState.Released);
            }
        }

        public bool PauseGame
        {
            get
            {
                return IsNewKeyPress(Keys.Escape)
                    || (CurrentGamePadState.Buttons.Back == ButtonState.Pressed
                        && LastGamePadState.Buttons.Back == ButtonState.Released)
                    || (CurrentGamePadState.Buttons.Start == ButtonState.Pressed
                        && LastGamePadState.Buttons.Start == ButtonState.Released);
            }
        }

        public bool MoveLeft
        {
            get
            {
                return CurrentKeyboardState.IsKeyDown(Keys.Left)
                    || CurrentGamePadState.DPad.Left == ButtonState.Pressed;
            }
        }

        public bool MoveRight
        {
            get
            {
                return CurrentKeyboardState.IsKeyDown(Keys.Right)
                    || CurrentGamePadState.DPad.Right == ButtonState.Pressed;
            }
        }

        public bool MoveUp
        {
            get
            {
                return CurrentKeyboardState.IsKeyDown(Keys.Up)
                    || CurrentGamePadState.DPad.Up == ButtonState.Pressed;
            }
        }

        public bool MoveDown
        {
            get
            {
                return CurrentKeyboardState.IsKeyDown(Keys.Down)
                    || CurrentGamePadState.DPad.Down == ButtonState.Pressed;
            }
        }

        public bool ShootBullet
        {
            get
            {
                return IsNewKeyPress(Keys.Space)
                    || (CurrentGamePadState.Buttons.A == ButtonState.Pressed
                        && LastGamePadState.Buttons.A == ButtonState.Released);
            }
        }

        public void Update()
        {
            LastKeyboardState = CurrentKeyboardState;
            LastGamePadState = CurrentGamePadState;
            CurrentKeyboardState = Keyboard.GetState();
            CurrentGamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public bool IsNewKeyPress(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key)
                && LastKeyboardState.IsKeyUp(key);
        }

        public bool OneOfKeysPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
                if (IsNewKeyPress(key))
                    return true;
            return false;
        }
    }
}
