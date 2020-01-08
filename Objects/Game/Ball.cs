using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Content;
using PongMonogame.System;
using System.Diagnostics;

namespace Pong_Monogame.Objects
{
    class Ball : ICollidableObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Radius { get; set; }
        public Vector2 Size { get; set; }

        private Texture2D sprite;
        public float Speed { get; set; }
        public string Tag { get; set; }
        private Match Match { get; set; }
        public int ID { get; set; }

        public Ball(int ID, Match Match, Vector2 Position, float Radius, float Speed = 6)
        {
            this.ID = ID;
            this.Match = Match;
            this.Position = Position;
            this.Radius = Radius;
            this.Size = new Vector2(this.Radius, this.Radius);
            //this.sprite = sprite;
            this.Direction = GetRandomDirection();
            this.Speed = Speed;
            Tag = "ball";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawCircle(Position, Radius, 8, Color.White);
            //spriteBatch.Draw(sprite, new Rectangle(Position.ToPoint(), Size.ToPoint()), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            MoveInDirection();
        }

        private Vector2 GetRandomDirection()
        {
            Random rand = new Random();

            //Chooses the Angle
            float angle = (float)rand.NextDouble() * MathHelper.TwoPi;

            //Normalised Direction
            Vector2 dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));

            return dir;
        }

        private void MoveInDirection()
        {
            if (Position.X <= Match.MatchSize.X || Position.X >= Match.MatchSize.Z)
            {
                Direction = new Vector2(-Direction.X, Direction.Y);
            }

            if (Position.Y <= Match.MatchSize.Y || Position.Y >= Match.MatchSize.W)
            {
                Direction = new Vector2(Direction.X, -Direction.Y);
            }

            Vector2 newPos = Direction * Speed;
            Position += newPos;
        }

        public void Load(ContentManager Content)
        {
            
        }

        public void Unload(ContentManager Content)
        {
            
        }

        public void OnCollisionEnter(ICollidableObject other)
        {
            if (!other.Tag.Equals("player"))
                return;


            //TODO: Identify where the ball hit on the player to apply a directional modifier

            Direction = new Vector2(-Direction.X, Direction.Y);
        }

        public void OnCollisionExit(ICollidableObject other)
        {
        }
    }
}
