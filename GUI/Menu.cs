using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong_Monogame;
using PongMonogame.GUI.Elements;
using PongMonogame.Objects;
using PongMonogame.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.GUI
{
    class Menu : IUpdate, IDraw, IContent, IState
    {
        // TODO: UPDATE THIS TO USE STATES!
        // MAIN MENU -> GAME SETTINGS MENU -> GAME -> MATCH RESULTS / STATS / REMATCH
        // EACH A DIFFERENT CLASS
        // MENU -> MENU -> MATCH -> MENU

        private GraphicsDeviceManager graphics;

        // Fonts
        private SpriteFont TitleFont;
        private SpriteFont MenuFont;

        // Options
        private Vector2 middlePoint;
        private List<Selection> menuOptions;
        private int selection = 0;

        // Input Keys
        List<Keys> UP_KEYS = new List<Keys>() { Keys.Up, Keys.W };
        List<Keys> DOWN_KEYS = new List<Keys>() { Keys.Down, Keys.S };
        List<Keys> ENTER_KEYS = new List<Keys>() { Keys.Enter, Keys.Space };

        public IState NextState { get; set; }
        public StateManager Manager { get; set; }

        public Menu(GraphicsDeviceManager graphics, StateManager Manager)
        {
            this.graphics = graphics;
            this.Manager = Manager;

            middlePoint = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        }

        public void Load(ContentManager Content)
        {
            // Fonts
            TitleFont = Content.Load<SpriteFont>("Fonts/TitleFont");
            MenuFont = Content.Load<SpriteFont>("Fonts/MenuFont");
        }

        public void Init()
        {
            menuOptions = new List<Selection>();
            menuOptions.Add(new Selection("Play", middlePoint, MenuFont, Play, true));
            menuOptions.Add(new Selection("Quit", new Vector2(middlePoint.X, middlePoint.Y), MenuFont, Quit));

            // Listen to Input Events
            Input.instance.KeyReleasedEvent += GetMenuMovement;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            DrawOptions(spriteBatch);
        }

        

        public void Update(GameTime gameTime)
        {
            // Dont know what needs updating
        }

        private void GetMenuMovement(Keys key)
        {
            Console.WriteLine("MENU DETECTED MOVEMENT");
            if (UP_KEYS.Contains(key)){
                MoveUp();
            } else if (DOWN_KEYS.Contains(key))
            {
                MoveDown();
            } else if (ENTER_KEYS.Contains(key))
            {
                Select();
            }
        }

        private void DrawOptions(SpriteBatch spriteBatch)
        {
            Vector2 fontSize = TitleFont.MeasureString("PONG");
            spriteBatch.DrawString(TitleFont, "PONG", new Vector2(middlePoint.X - (fontSize.X / 2),fontSize.Y), Color.White);

            for (int i = 0; i < menuOptions.Count; i++)
            {
                menuOptions[i].SelectionNum = i;
                menuOptions[i].Draw(spriteBatch);
            }
        }

        // Menu
        private void MoveUp()
        {
            // Check if we're the top option
            if (selection <= 0)
                return;
            // Update
            menuOptions[selection].Selected = false;
            selection--;
            menuOptions[selection].Selected = true;
        }

        private void MoveDown()
        {
            // Check if we're the bottom option
            if (selection >= menuOptions.Count-1)
                return;
            // Update
            menuOptions[selection].Selected = false;
            selection++;
            menuOptions[selection].Selected = true;
        }

        private void Select()
        {
            menuOptions[selection].Callback();
        }

        public void Play()
        {
            //TODO: GOTO GAME SETTINGS MENU (1VCPU,1V1)
            gameMatch = new Match(Manager, this);
            NextState = gameMatch;
            Manager.NextState();
        }

        public void Quit()
        {
            PongGame.Instance.Exit();
        }

        public void Load()
        {
            // Fonts
            TitleFont = Manager.Content.Load<SpriteFont>("Fonts/TitleFont");
            MenuFont = Manager.Content.Load<SpriteFont>("Fonts/MenuFont");
        }

        public void Unload()
        {
            
        }

        public void UnLoad(ContentManager Content)
        {
            
        }
    }
}
