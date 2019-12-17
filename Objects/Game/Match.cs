using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.Objects;
using PongMonogame.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    class Match : IDraw, IUpdate
    {
        public Background MatchBackground { get; set; }
        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
