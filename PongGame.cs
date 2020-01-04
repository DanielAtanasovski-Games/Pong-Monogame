using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong_Monogame.Objects;
using PongMonogame.GUI;
using PongMonogame.System;
using PongMonogame.World;

namespace Pong_Monogame
{
    public class PongGame : Game
    {
        public GraphicsDeviceManager Graphics;
        private SpriteBatch spriteBatch;

        // Singleton
        public static PongGame Instance;

        // Load Resource 
        // TODO: Seperate this out to class specifics
        //SpriteFont gameFont;
        //private Texture2D ballSprite;
        
        //// Objects
        //// TODO: Move this to Match Class
        //private Background line;
        //private Pong player;
        //private Ball ball;
        
        //private Menu menu;
        //private GAMESTATE gameState;

        GameManager Manager;

        public PongGame()
        {
            Instance = this;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Manager = new GameManager(Content);
        }

        protected override void Initialize()
        {
            //line = new Background(new Vector2(0, 0), new Vector2(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight));
            //player = new Pong(new Vector2(20, 100), new Vector2(10, 40));

            // Menu
            //menu = new Menu(Graphics, );
            
           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Manager.LoadCurrentState();

            ////gameFont = Content.Load<SpriteFont>("Fonts/GameFont");
            //ballSprite = Content.Load<Texture2D>("Sprites/Ball");

            //ball = new Ball(new Vector2(200, 150), 16, ballSprite);

            //menu.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            Input.instance.Update(gameTime);
            Manager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            Manager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            Manager.UnloadCurrentState();
            base.OnExiting(sender, args);
        }

    }
}
