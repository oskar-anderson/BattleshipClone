using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch = default!;
        private SpriteFont _spriteFont = default!;
        private int frameCount = 0;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 960;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            _graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 1000);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Content.Load<SpriteFont>("builtContent/PressStart2pFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            var width = 40;
            var height = 40;
            var chars = "zxcasdqwe";
            var random = new Random();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _spriteBatch.Begin();
                    _spriteBatch.DrawString(_spriteFont, chars[random.Next() % chars.Length].ToString(), new Vector2(x * 16, y * 16), Color.White);
                    _spriteBatch.End();
                }
            }

            frameCount++;
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_spriteFont, $"FrameCount: {frameCount}", new Vector2(40, 700), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
