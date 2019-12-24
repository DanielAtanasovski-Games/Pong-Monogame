using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.Objects.Characters
{
    public enum CharacterSize
    {
        Small,
        Medium,
        Large
    }
    class HumanPlayer : IPlayer
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public int MoveSpeed { get; set; }

        public HumanPlayer(Vector2 Position, Vector2 Size, int MoveSpeed = 10)
        {
            this.Position = Position;
            this.Size = Size;
            this.MoveSpeed = MoveSpeed;

        }

        public HumanPlayer(Vector2 Position, CharacterSize Size, int MoveSpeed = 10)
        {
            this.Position = Position;
            IPlayer intPlayer = (IPlayer)this;
            this.Size = intPlayer.CalculateSize(Size);
            this.MoveSpeed = MoveSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D tex = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            tex.SetData(new[] { Color.White });

            spriteBatch.Draw(tex, new Rectangle(Position.ToPoint(), Size.ToPoint()), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Position = new Vector2(Position.X, Position.Y - MoveSpeed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Position = new Vector2(Position.X, Position.Y + MoveSpeed);
            }
        }

        public void PositionInBounds(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void ObjectInBounds(Vector2 position, Vector2 size)
        {
            throw new NotImplementedException();
        }

        public void Load(ContentManager Content)
        {
            throw new NotImplementedException();
        }

        public void UnLoad(ContentManager Content)
        {
            throw new NotImplementedException();
        }
    }
}
