using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.GUI.Elements;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.GUI
{
    class Menu : IUpdate, IDraw, ILoadContent
    {
        private List<Selection> menuOptions;
        private GraphicsDeviceManager graphics;

        private SpriteFont TitleFont;
        private SpriteFont MenuFont;
        private Vector2 middlePoint;

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
            menuOptions.Add(new Selection("Play", middlePoint, MenuFont, true));
            menuOptions.Add(new Selection("Quit", new Vector2(middlePoint.X, middlePoint.Y), MenuFont));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawOptions(spriteBatch);
        }

        

        public void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
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
    }
}
