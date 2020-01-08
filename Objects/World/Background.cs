using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.World
{
    class Background : IObject
    {
        List<Rectangle> levelLines { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public string Tag { get; set; }
        public int ID { get; set; }

        public Background(int ID, Vector2 Position, Vector2 Size)
        {
            this.ID = ID;
            this.Position = Position;
            this.Size = Size;

            levelLines = new List<Rectangle>(){
                // TOP
                new Rectangle((int)Position.X, (int)Position.Y, (int)(Size.X), 4),
                // BOTTOM
                new Rectangle((int)Position.X, (int)(Position.Y + Size.Y) - 4, (int)(Size.X), (int)(Size.Y)),
                // Middle
                new Rectangle((int)(Position.X + (Size.X / 2) - 2), (int)Position.Y, 4, (int)(Size.Y)),
                // LEFT SIDE
                new Rectangle((int)Position.X, (int)Position.Y, 4, (int)(Size.Y)),
                // RIGHT SIDE
                new Rectangle((int)(Position.X + Size.X) - 4, (int)Position.Y, (int)(Size.X), (int)(Size.Y))
            };

            Tag = "background";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D lineTex = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            lineTex.SetData(new[] { Color.Gray });

            // Draw Collision Bounds
            for (int i = 0; i < levelLines.Count; i++)
            {
                spriteBatch.Draw(lineTex, levelLines[i], Color.White);
            }
        }

        public void Load(ContentManager Content)
        {

        }

        public void Unload(ContentManager Content)
        {

        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
  