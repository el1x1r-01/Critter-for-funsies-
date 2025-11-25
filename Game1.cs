using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Critter__for_funsies_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator = new Random();

        Rectangle window, fenceForeRect, fenceBackRect, fieldRect, frodoRect, samRect, pipRect, tempCarrotRect, heartRect;

        Texture2D fenceForeTexture, fenceBackTexture, fieldTexture, frodoTexture, samTexture, pipTexture, carrotTexture, heartTexture;

        Vector2 frodoSpeed, frodoFontVector2, samSpeed, samFontVector2, pipSpeed, pipFontVector2;

        float seconds, delay, frodoHeart, samHeart, pipHeart;

        SpriteEffects frodoEffect, samEffect, pipEffect;

        int frodo, sam, pip;

        SpriteFont frodoFont, samFont, pipFont;

        MouseState mouseState;

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

            samRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 150, 150);
            samSpeed = new Vector2(2, 2);
            sam = 1;

            pipRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 175, 175);
            pipSpeed = new Vector2(2, 2);
            pip = 1;

            for (int i = 0; i < 1; i++)
            {
                tempCarrotRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 75, 75);
            }

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
            frodoFont = Content.Load<SpriteFont>("Frodo");

            samTexture = Content.Load<Texture2D>("SamwiseBunny-1.png");
            samFont = Content.Load<SpriteFont>("Samwise");

            pipTexture = Content.Load<Texture2D>("PippinBunny-1.png");
            pipFont = Content.Load<SpriteFont>("Pippin");

            carrotTexture = Content.Load<Texture2D>("Carrot");
            heartTexture = Content.Load<Texture2D>("heart V3");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

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

                sam++;

                if (sam == 1)
                {
                    samTexture = Content.Load<Texture2D>("SamwiseBunny-1.png");
                }
                else if (sam == 10)
                {
                    samTexture = Content.Load<Texture2D>("SamwiseBunny-2.png");
                }
                else if (sam == 20)
                {
                    samTexture = Content.Load<Texture2D>("SamwiseBunny-3.png");
                }
                else if (sam == 30)
                {
                    samTexture = Content.Load<Texture2D>("SamwiseBunny-4.png");
                    sam = 1;
                }

                pip++;

                if (pip == 1)
                {
                    pipTexture = Content.Load<Texture2D>("PippinBunny-1.png");
                }
                else if (pip == 10)
                {
                    pipTexture = Content.Load<Texture2D>("PippinBunny-2.png");
                }
                else if (pip == 20)
                {
                    pipTexture = Content.Load<Texture2D>("PippinBunny-3.png");
                }
                else if (pip == 30)
                {
                    pipTexture = Content.Load<Texture2D>("PippinBunny-4.png");
                    pip = 1;
                }
            }

            frodoRect.X += (int)frodoSpeed.X;
            frodoRect.Y += (int)frodoSpeed.Y;

            if (frodoSpeed.X > 0)
            {
                frodoEffect = SpriteEffects.FlipHorizontally;
            }
            else if (frodoSpeed.X < 0)
            {
                frodoEffect = SpriteEffects.None;
            }

            if (frodoRect.Right > 735 || frodoRect.Left < 75)
            {
                frodoSpeed.X *= -1;

                if (frodoSpeed.Y < 0)
                {
                    frodoSpeed.Y = (generator.Next(-5, 1));
                }
                else
                {
                    frodoSpeed.Y = (generator.Next(0, 6));
                }
            }

            if (frodoRect.Bottom > 750 || frodoRect.Top < 100)
            {
                frodoSpeed.Y *= -1;

                if (frodoSpeed.X < 0)
                {
                    frodoSpeed.X = (generator.Next(-5, 1));
                }
                else
                {
                    frodoSpeed.X = (generator.Next(0, 6));
                }
            }

            if (frodoRect.Contains(mouseState.Position))
            {
                frodoFontVector2 = new Vector2((frodoRect.X) + 50, (frodoRect.Y) + 115);
            }
            else
            {
                frodoFontVector2 = new Vector2(-100, -100);
            }

            if (frodoRect.X <= 0 || frodoRect.Left >= 800 || frodoRect.Y <= 0 || frodoRect.Bottom >= 800)
            {
                frodoRect.X = 350;
                frodoRect.Y = 350;
            }

            if (frodoRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
            {
                frodoRect.X = (mouseState.X - 50);
                frodoRect.Y = (mouseState.Y - 50);

                if (mouseState.X < 75 || mouseState.X > 700 || mouseState.Y < 150 || mouseState.Y > 625)
                {
                    frodoRect.X = 350;
                    frodoRect.Y = 350;
                }
            }

            samRect.X += (int)samSpeed.X;
            samRect.Y += (int)samSpeed.Y;

            if (samSpeed.X > 0)
            {
                samEffect = SpriteEffects.FlipHorizontally;
            }
            else if (samSpeed.X < 0)
            {
                samEffect = SpriteEffects.None;
            }

            if (samRect.Right > 735 || samRect.Left < 75)
            {
                samSpeed.X *= -1;

                if (samSpeed.Y < 0)
                {
                    samSpeed.Y = (generator.Next(-5, 1));
                }
                else
                {
                    samSpeed.Y = (generator.Next(0, 6));
                }
            }

            if (samRect.Bottom > 750 || samRect.Top < 100)
            {
                samSpeed.Y *= -1;

                if (samSpeed.X < 0)
                {
                    samSpeed.X = (generator.Next(-5, 1));
                }
                else
                {
                    samSpeed.X = (generator.Next(0, 6));
                }
            }

            if (samRect.Contains(mouseState.Position))
            {
                samFontVector2 = new Vector2((samRect.X) + 40, (samRect.Y) + 115);
            }
            else
            {
                samFontVector2 = new Vector2(-100, -100);
            }

            if (samRect.X <= 0 || samRect.Left >= 800 || samRect.Y <= 0 || samRect.Bottom >= 800)
            {
                samRect.X = 350;
                samRect.Y = 350;
            }

            if (samRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
            {
                samRect.X = (mouseState.X - 50);
                samRect.Y = (mouseState.Y - 50);

                if (mouseState.X < 75 || mouseState.X > 735 || mouseState.Y < 150 || mouseState.Y > 650)
                {
                    samRect.X = 350;
                    samRect.Y = 350;
                }
            }

            pipRect.X += (int)pipSpeed.X;
            pipRect.Y += (int)pipSpeed.Y;

            if (pipSpeed.X > 0)
            {
                pipEffect = SpriteEffects.FlipHorizontally;
            }
            else if (pipSpeed.X < 0)
            {
                pipEffect = SpriteEffects.None;
            }

            if (pipRect.Right > 735 || pipRect.Left < 75)
            {
                pipSpeed.X *= -1;

                if (pipSpeed.Y < 0)
                {
                    pipSpeed.Y = (generator.Next(-5, 1));
                }
                else
                {
                    pipSpeed.Y = (generator.Next(0, 6));
                }
            }

            if (pipRect.Bottom > 750 || pipRect.Top < 100)
            {
                pipSpeed.Y *= -1;

                if (pipSpeed.X < 0)
                {
                    pipSpeed.X = (generator.Next(-5, 1));
                }
                else
                {
                    pipSpeed.X = (generator.Next(0, 6));
                }
            }

            if (pipRect.Contains(mouseState.Position))
            {
                pipFontVector2 = new Vector2((pipRect.X) + 70, (pipRect.Y) + 130);
            }
            else
            {
                pipFontVector2 = new Vector2(-100, -100);
            }

            if (pipRect.X <= 0 || pipRect.Left >= 800 || pipRect.Y <= 0 || pipRect.Bottom >= 800)
            {
                pipRect.X = 350;
                pipRect.Y = 350;
            }

            if (pipRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
            {
                pipRect.X = (mouseState.X - 50);
                pipRect.Y = (mouseState.Y - 50);

                if (mouseState.X < 75 || mouseState.X > 735 || mouseState.Y < 150 || mouseState.Y > 650)
                {
                    pipRect.X = 350;
                    pipRect.Y = 350;
                }
            }

            if (frodoRect.Contains(tempCarrotRect))
            {
                tempCarrotRect = new Rectangle(-100, -100, 75, 75);
                frodoHeart = 300;
            }
            if (samRect.Contains(tempCarrotRect))
            {
                tempCarrotRect = new Rectangle(-100, -100, 75, 75);
                samHeart = 300;
            }
            if (pipRect.Contains(tempCarrotRect))
            {
                tempCarrotRect = new Rectangle(-100, -100, 75, 75);
                pipHeart = 300;
            }

            if (tempCarrotRect.X == -100)
            {
                delay = generator.Next(150, 1500);
                tempCarrotRect = new Rectangle(-101, -100, 75, 75);
            }
            if(tempCarrotRect.X == -101)
            {
                delay--;

                if (delay < 0)
                {
                    tempCarrotRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 75, 75);
                }
            }

            if (frodoHeart > 0)
            {
                frodoHeart--;

                if (frodoEffect == SpriteEffects.None)
                {
                    heartRect = new Rectangle((frodoRect.X + 20), (frodoRect.Y - 30), 50, 50);
                }
                else
                {
                    heartRect = new Rectangle((frodoRect.X + 70), (frodoRect.Y - 30), 50, 50);
                }
            }
            if (samHeart > 0)
            {
                samHeart--;

                if (samEffect == SpriteEffects.None)
                {
                    heartRect = new Rectangle((samRect.X + 20), (samRect.Y - 30), 50, 50);
                }
                else
                {
                    heartRect = new Rectangle((samRect.X + 70), (samRect.Y - 30), 50, 50);
                }
            }
            if (pipHeart > 0)
            {
                pipHeart--;

                if (pipEffect == SpriteEffects.None)
                {
                    heartRect = new Rectangle((pipRect.X + 30), (pipRect.Y - 30), 50, 50);
                }
                else
                {
                    heartRect = new Rectangle((pipRect.X + 85), (pipRect.Y - 30), 50, 50);
                }
            }

            if (frodoHeart <= 0 && samHeart <= 0 && pipHeart <= 0)
            {
                heartRect = new Rectangle(-100, -100, 50, 50);
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

            _spriteBatch.Draw(carrotTexture, tempCarrotRect, Color.White);

            _spriteBatch.Draw(frodoTexture, frodoRect, null, Color.White, 0f, Vector2.Zero, frodoEffect, 0f);
            _spriteBatch.Draw(samTexture, samRect, null, Color.White, 0f, Vector2.Zero, samEffect, 0f);
            _spriteBatch.Draw(pipTexture, pipRect, null, Color.White, 0f, Vector2.Zero, pipEffect, 0f);

            _spriteBatch.Draw(fenceForeTexture, fenceForeRect, Color.White);

            _spriteBatch.DrawString(frodoFont, "Frodo", frodoFontVector2, Color.White);
            _spriteBatch.DrawString(samFont, "Samwise", samFontVector2, Color.White);
            _spriteBatch.DrawString(pipFont, "Pippin", pipFontVector2, Color.White);

            _spriteBatch.Draw(heartTexture, heartRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
