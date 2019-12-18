using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.GUI.Elements
{
    class Selection : IDraw
    {

        public string Text { get; set; }
        public bool Selected { get; set; }
        public Vector2 Position { get; set; }
        public SpriteFont Font { get; set; }
        public int SelectionNum { get; set; }

        // TODO:
        public Action Callback{ get; set; }
        

        private readonly Color selectedColor = Color.Red;
        private readonly Color defaultColor = Color.White;

        public Selection(string Text, Vector2 Position , SpriteFont Font, Action Callback, bool Selected = false)
        {
            this.Text = Text;
            this.Selected = Selected;
            this.Font = Font;
            this.Position = Position;
            this.Callback = Callback;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 fontSize = Font.MeasureString(Text);
            Vector2 pos = new Vector2(Position.X - (fontSize.X / 2), Position.Y - (fontSize.Y / 2) + (SelectionNum * fontSize.Y));

            if (Selected)
                spriteBatch.DrawString(Font, Text, pos, selectedColor);
            else
                spriteBatch.DrawString(Font, Text, pos, defaultColor);
        }
    }
}
