using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Critter__for_funsies_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator = new Random();

        Rectangle window, fenceForeRect, fenceBackRect, fieldRect, frodoRect;

        Texture2D fenceForeTexture, fenceBackTexture, fieldTexture, frodoTexture;

        Vector2 frodoSpeed;

        float seconds;

        SpriteEffects frodoEffect;

        int frodo;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 800);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            fenceBackRect = new Rectangle(50, 50, 700, 700);
            fenceForeRect = new Rectangle(50, 50, 700, 700);
            fieldRect = new Rectangle(0, 0, 800, 800);

            frodoRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 150, 150);
            frodoSpeed = new Vector2(2, 2);
            frodo = 1;

            seconds = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            fenceBackTexture = Content.Load<Texture2D>("FenceBackground");
            fenceForeTexture = Content.Load<Texture2D>("FenceForeground");
            fieldTexture = Content.Load<Texture2D>("Field V2");

            frodoTexture = Content.Load<Texture2D>("FrodoBunny-1.png");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (seconds > 0)
            {
                frodo++;
                
                if (frodo == 1)
                {
                    frodoTexture = Content.Load<Texture2D>("FrodoBunny-1.png");
                }
                else if (frodo == 10)
                {
                    frodoTexture = Content.Load<Texture2D>("FrodoBunny-2.png");
                }
                else if (frodo == 20)
                {
                    frodoTexture = Content.Load<Texture2D>("FrodoBunny-3.png");
                }
                else if (frodo == 30)
                {
                    frodoTexture = Content.Load<Texture2D>("FrodoBunny-4.png");
                    frodo = 1;
                }
            }

            frodoRect.X += (int)frodoSpeed.X;
            frodoRect.Y += (int)frodoSpeed.Y;

            if (frodoRect.Right > 735 || frodoRect.Left < 75)
            {
                frodoSpeed.X *= -1;

                if (frodoSpeed.X > 0)
                {

                }
                if (frodoSpeed.X < 0)
                {

                }
            }

            if (frodoRect.Bottom > 750 || frodoRect.Top < 100)
            {
                frodoSpeed.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(fieldTexture, fieldRect, Color.White);
            _spriteBatch.Draw(fenceBackTexture, fenceBackRect, Color.White);

            _spriteBatch.Draw(frodoTexture, frodoRect, Color.White);

            _spriteBatch.Draw(fenceForeTexture, fenceForeRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
