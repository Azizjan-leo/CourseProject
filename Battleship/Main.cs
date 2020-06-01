using Battleship.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Battleship
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background_Sprite;

        bool fin = false; // End of the game
        Texture2D finBackGround;

        SpriteFont mainFont;
        SpriteFont axisFont;

        GamePlay game;
        DrawHelper shipHelper;

        MouseState mState;
        bool mRealesed = true;

        int[] cpuAliveShips = new int[] { 10, 4, 3, 2, 1 };
        int[] userAliveShips = new int[] { 10, 4, 3, 2, 1 };

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            // TODO: use this.Content to load your game content here
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background_Sprite = Content.Load<Texture2D>("background");
            mainFont = Content.Load<SpriteFont>("font");
            axisFont = Content.Load<SpriteFont>("asixfont");
            shipHelper = new DrawHelper(spriteBatch, Content.Load<Texture2D>("5ship"), Content.Load<Texture2D>("0ship"), Content.Load<Texture2D>("missShot"));
     
            game = new GamePlay(10);
            game.PlaceShips();   
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (!fin)
            {
                mState = Mouse.GetState();

                if (mState.LeftButton == ButtonState.Pressed && mRealesed == true)
                {
                    game.Shot(mState.X, mState.Y, shipHelper);

                    cpuAliveShips = game.GetCpuAliveShipsNum();
                    if (cpuAliveShips[0] == 0)
                    {
                        fin = true;
                        finBackGround = Content.Load<Texture2D>("winBackground");
                    }
                    userAliveShips = game.GetUserAliveShipsNum();
                    if (userAliveShips[0] == 0)
                    {
                        fin = true;
                        finBackGround = Content.Load<Texture2D>("looseBackground");
                    }

                    mRealesed = false;
                }

                if (mState.LeftButton == ButtonState.Released)
                {
                    mRealesed = true;
                }
            }
            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (fin)
            {
                spriteBatch.Draw(finBackGround, new Vector2(0, 0), Color.White);
                string result = (game.GetCpuAliveShipsNum()[0] == 0) ? "WIN" : "LOOSE";
                spriteBatch.DrawString(mainFont, $"YOU {result}!", new Vector2(12, 23), Color.White);
            }
            else
            {
                spriteBatch.Draw(background_Sprite, new Vector2(0, 0), Color.White);

                
                for (int i = 1; i < 5; i++)
                {
                    spriteBatch.DrawString(axisFont, $"{i} deck ships: {cpuAliveShips[i]}", new Vector2(110, i * 20 - 10), Color.White);
                }
                for (int i = 1; i < 5; i++)
                {
                    spriteBatch.DrawString(axisFont, $"{i} deck ships: {userAliveShips[i]}", new Vector2(510, i * 20 - 10), Color.White);
                }
                game.DrawShips(shipHelper);
                shipHelper.DrawMissShots();
            }
           
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    }
#endif
}
