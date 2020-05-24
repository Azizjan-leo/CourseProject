using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace shootingGame
{
    
    public class Game1 : Game
    {
        #region VarsDecloration
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D target_Sprite;
        Texture2D crosshairs_Sprite;
        Texture2D background_Sprite;

        SpriteFont gameFont;

        Vector2 targetPosition;

        const int TARGET_RADIUS = 45;

        MouseState mState;
        bool mRealesed;
        float mouseTargetDist;

        int score;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            targetPosition = new Vector2(200, 200);
            score = 0;
            mRealesed = true;
            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            target_Sprite = Content.Load<Texture2D>("target");
            crosshairs_Sprite = Content.Load<Texture2D>("crosshairs");
            background_Sprite = Content.Load<Texture2D>("sky");

            gameFont = Content.Load<SpriteFont>("galleryFont");
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

      
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mState = Mouse.GetState();

            mouseTargetDist = Vector2.Distance(targetPosition, new Vector2(mState.X, mState.Y));

            if(mState.LeftButton == ButtonState.Pressed && mRealesed == true)
            {
                if (mouseTargetDist < TARGET_RADIUS)
                {
                    score++;

                    Random random = new Random();

                    targetPosition.X = random.Next(TARGET_RADIUS, this.GraphicsDevice.Viewport.Width - TARGET_RADIUS);
                    targetPosition.Y = random.Next(TARGET_RADIUS, this.GraphicsDevice.Viewport.Height - TARGET_RADIUS);
                }
                mRealesed = false;
            }

            if (mState.LeftButton == ButtonState.Released)
            {
                mRealesed = true;
            }
            base.Update(gameTime);
        }

  
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background_Sprite, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(target_Sprite, new Vector2(targetPosition.X - TARGET_RADIUS, targetPosition.Y - TARGET_RADIUS), Color.White);
            
            spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(0, 000), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
