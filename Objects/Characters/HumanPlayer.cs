using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongMonogame.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

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
        Match Match;
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public int MoveSpeed { get; set; }
        public string Tag { get; set; }
        public int ID { get; set; }

        public HumanPlayer(int ID, Match Match, Vector2 Position, Vector2 Size, int MoveSpeed = 10)
        {
            this.ID = ID;
            this.Match = Match;
            this.Position = Position;
            this.Size = Size;
            this.MoveSpeed = MoveSpeed;
            Tag = "player";
        }

        public HumanPlayer(int ID, Match Match, Vector2 Position, CharacterSize Size, int MoveSpeed = 10)
        {
            this.ID = ID;
            this.Match = Match;
            this.Position = Position;
            IPlayer intPlayer = (IPlayer)this;
            this.Size = intPlayer.CalculateSize(Size);
            this.MoveSpeed = MoveSpeed;
            Tag = "player";
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
                if (Match.ValidPosition(this, -MoveSpeed))
                    Position = new Vector2(Position.X, Position.Y - MoveSpeed);
                else
                    IncrementPosition(-MoveSpeed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (Match.ValidPosition(this, MoveSpeed))
                    Position = new Vector2(Position.X, Position.Y + MoveSpeed);
                else
                    IncrementPosition(MoveSpeed);
            }

        }

        private void IncrementPosition(int speed)
        {
            bool invalidPos = false;
            Vector2 currentPos = new Vector2(Position.X, Position.Y);
            Vector2 increment = new Vector2(0, Math.Sign(speed));

            while (!invalidPos)
            {
                if (Match.ValidPosition(ID, currentPos, Size, Math.Sign(speed)))
                {
                    currentPos += increment;
                }
                else
                {
                    Position = currentPos;
                    invalidPos = true;
                }
                    
            }
        }

        public void Load(ContentManager Content)
        {
            throw new NotImplementedException();
        }

        public void Unload(ContentManager Content)
        {
            
        }

        public void OnCollisionEnter()
        {
            throw new NotImplementedException();
        }

        public void OnCollisionExit()
        {
            throw new NotImplementedException();
        }
    }
}
