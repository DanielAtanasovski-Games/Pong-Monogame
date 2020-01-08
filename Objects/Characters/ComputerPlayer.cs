using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PongMonogame.Objects.Characters
{
    class ComputerPlayer : IPlayer
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public string Tag { get; set; }
        public int ID { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Load(ContentManager Content)
        {
            throw new NotImplementedException();
        }

        public void OnCollisionEnter(ICollidableObject other)
        {
            throw new NotImplementedException();
        }

        public void OnCollisionExit(ICollidableObject other)
        {
            throw new NotImplementedException();
        }

        public void Unload(ContentManager Content)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
