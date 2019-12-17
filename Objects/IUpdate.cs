using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.Objects
{
    public interface IUpdate
    {
        void Update(GameTime gameTime);
    }
}
