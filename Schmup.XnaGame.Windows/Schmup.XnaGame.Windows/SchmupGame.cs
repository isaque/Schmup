using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schmup.XnaGame.Common;
using Schmup.XnaGame.Debug;
using Schmup.XnaGame.Menus;

namespace Schmup.XnaGame
{
    public class SchmupGame : Game
    {
        public InputState InputState { get; private set; }

        public MainMenu MainMenu { get; private set; }
        public OptionsMenu OptionsMenu { get; private set; }

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public SchmupGame()
        {
            Window.Title = "Schmup";
            Window.AllowUserResizing = false;
            IsMouseVisible = false;

            graphics = new GraphicsDeviceManager(this);
            graphics.SynchronizeWithVerticalRetrace = false;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = false;

            // Set the framerate at 62.5 fps (i.e. about 60 fps)
            IsFixedTimeStep = true;
            TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 16);

            Content.RootDirectory = "Content";

            InputState = new InputState();

            MainMenu = new MainMenu(this);
            Components.Add(MainMenu);
            OptionsMenu = new OptionsMenu(this);
            Components.Add(OptionsMenu);

#if DEBUG
            FrameRateCounter frameRateCounter = new FrameRateCounter(this);
            frameRateCounter.DrawOrder = 101;
            Components.Add(frameRateCounter);
            ComponentsTracer componentsTracer = new ComponentsTracer(this);
            componentsTracer.DrawOrder = 102;
            componentsTracer.AddComponent("Main Menu", MainMenu);
            componentsTracer.AddComponent("Options Menu", OptionsMenu);
            Components.Add(componentsTracer);
#endif
        }

        #region Game Members

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            InputState.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }

        #endregion
    }
}
