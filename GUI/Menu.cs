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
    class Menu : IUpdate, IDraw, ILoadContent
    {
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

        public Menu(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;


            middlePoint = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        }

        public void LoadContent(ContentManager Content)
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
            
        }

        public void Quit()
        {
            PongGame.Instance.Exit();
        }
    }
}
