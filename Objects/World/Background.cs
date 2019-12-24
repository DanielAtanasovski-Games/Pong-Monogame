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

        public Background(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }

        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D lineTex = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            lineTex.SetData(new[] { Color.Gray });

            // TOP
            spriteBatch.Draw(lineTex, new Rectangle((int)Position.X, (int)Position.Y, (int)(Size.X), 4), Color.White);
            // MIDDLE
            spriteBatch.Draw(lineTex, new Rectangle((int)(Position.X + (Size.X / 2) - 2), (int)Position.Y, 4, (int)(Size.Y)), Color.White);
            // BOTTOM
            spriteBatch.Draw(lineTex, new Rectangle((int)Position.X, (int)(Position.Y + Size.Y) - 4, (int)(Size.X), (int)(Size.Y)), Color.White);
            // LEFT SIDE
            spriteBatch.Draw(lineTex, new Rectangle((int)Position.X, (int)Position.Y, 4, (int)(Size.Y)), Color.White);
            // RIGHT SIDE
            spriteBatch.Draw(lineTex, new Rectangle((int)(Position.X + Size.X) - 4, (int)Position.Y, (int)(Size.X), (int)(Size.Y)), Color.White);
        }

        public void Load(ContentManager Content)
        {

        }

        public void UnLoad(ContentManager Content)
        {

        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
  