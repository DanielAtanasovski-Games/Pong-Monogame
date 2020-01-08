//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using PongMonogame.Objects;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Pong_Monogame.Objects
//{
//    class Pong : IObject
//    {
//        public Vector2 Position { get; set; }
//        public Vector2 Size { get; set; }

//        public int MoveSpeed { get; set; }

//        public Pong(Vector2 Position, Vector2 Size, int MoveSpeed = 10)
//        {
//            this.Position = Position;
//            this.Size = Size;
//            this.MoveSpeed = MoveSpeed;
//        }

//        public void Draw(SpriteBatch spriteBatch)
//        {
//            Texture2D tex = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
//            tex.SetData(new[] { Color.White });

//            spriteBatch.Draw(tex, new Rectangle(Position.ToPoint(), Size.ToPoint()), Color.White);
//        }

//        public void Update(GameTime gameTime)
//        {
//            if (Keyboard.GetState().IsKeyDown(Keys.Up))
//            {
//                Position = new Vector2(Position.X, Position.Y - MoveSpeed);
//            } else if (Keyboard.GetState().IsKeyDown(Keys.Down))
//            {
//                Position = new Vector2(Position.X, Position.Y + MoveSpeed);
//            }
//        }

//        public void Load(ContentManager Content)
//        {
            
//        }

//        public void Unload(ContentManager Content)
//        {
            
//        }
//    }
//}
