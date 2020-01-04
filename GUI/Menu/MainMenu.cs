using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong_Monogame;
using PongMonogame.GUI.Elements;
using PongMonogame.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.GUI
{
    class MainMenu : Menu
    {
        // Fonts
        private SpriteFont TitleFont;
        private SpriteFont MenuFont;

        public MainMenu(StateManager Manager) : base(Manager)
        {
            this.Manager = Manager;
        }

        public override void Load(ContentManager Content)
        {
            // Fonts
            TitleFont = Content.Load<SpriteFont>("Fonts/TitleFont");
            MenuFont = Content.Load<SpriteFont>("Fonts/MenuFont");
        }

        public override void Init()
        {
            menuOptions = new List<Selection>
            {
                new Selection("Play", middlePoint, MenuFont, Play, true),
                new Selection("Quit", new Vector2(middlePoint.X, middlePoint.Y), MenuFont, Quit)
            };

            // Listen to Input Events
            Input.instance.KeyReleasedEvent += GetMenuMovement;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 fontSize = TitleFont.MeasureString("PONG");
            spriteBatch.DrawString(TitleFont, "PONG", new Vector2(middlePoint.X - (fontSize.X / 2), fontSize.Y), Color.White);
            DrawOptions(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Unload(ContentManager Content)
        {

        }

        public void Play()
        {
            //TODO: GOTO GAME SETTINGS MENU (1VCPU,1V1)
            MenuManager m = (MenuManager)Manager;

            MatchManager gameMatch = new MatchManager(Manager.Content, m.Manager);
            Manager.NextState(gameMatch);
        }

        public void Quit()
        {
            PongGame.Instance.Exit();
        }
    }
}
