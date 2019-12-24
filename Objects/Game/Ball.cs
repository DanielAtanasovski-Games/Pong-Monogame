using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Content;

namespace Pong_Monogame.Objects
{
    class Ball : IObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Radius { get; set; }
        public Vector2 Size { get; set; }

        private Texture2D sprite;
        public float Speed { get; set; }

        public Ball(Vector2 Position, float Radius, Texture2D sprite)
        {
            this.Position = Position;
            this.Radius = Radius;
            this.Size = new Vector2(this.Radius, this.Radius);
            this.sprite = sprite;
            this.Direction = GetRandomDirection();
            this.Speed = 1f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawCircle(Position, Radius, 8, Color.White);
            spriteBatch.Draw(sprite, new Rectangle(Position.ToPoint(), Size.ToPoint()), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            MoveInDirection(Direction);
            CollisionCheck();
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

        private void MoveInDirection(Vector2 direction)
        {
            Vector2 newPos = Direction * Speed;
            Position += newPos;
        }

        private void CollisionCheck()
        {
            //TODO: GET THE WIDTH AND HEIGHT FROM MANAGER CLASS (TODO)
            if (Position.X <= 0 || Position.X >= 400)
            {
                Direction = new Vector2(-Direction.X, Direction.Y);
            }

            if (Position.Y <= 0 || Position.Y >= 400)
            {
                Direction = new Vector2(Direction.X, -Direction.Y);
            }
        }

        public void Load(ContentManager Content)
        {
            
        }

        public void UnLoad(ContentManager Content)
        {
            
        }
    }
}
