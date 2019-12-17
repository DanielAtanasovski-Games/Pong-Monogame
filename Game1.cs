using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong_Monogame.Objects;
using PongMonogame.GUI;
using PongMonogame.World;

namespace Pong_Monogame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Singleton
        public static Game1 self;

        // Load Resource 
        // TODO: Seperate this out to class specifics
        SpriteFont gameFont;
        Texture2D ballSprite;

        // Objects
        // TODO: Move this to Match Class
        Background line;
        Pong player;
        Ball ball;
        
        Menu menu;

        public Game1()
        {
            self = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            line = new Background(new Vector2(0, 0), new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            player = new Pong(new Vector2(20, 100), new Vector2(10, 40));
            // Menu
            menu = new Menu(graphics);
           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //gameFont = Content.Load<SpriteFont>("Fonts/GameFont");
            ballSprite = Content.Load<Texture2D>("Sprites/Ball");

            ball = new Ball(new Vector2(200, 150), 16, ballSprite);

            menu.LoadContent(Content);

            OnLoadContentDone();
        }

        private void OnLoadContentDone()
        {
            menu.Init();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //player.Update(gameTime);
            //ball.Update(gameTime);
            menu.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            menu.Draw(spriteBatch);

            //spriteBatch.DrawString(gameFont, "Hello, World!", new Vector2(100, 100), Color.White);
            //line.Draw(spriteBatch);
            //player.Draw(spriteBatch);
            //ball.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
