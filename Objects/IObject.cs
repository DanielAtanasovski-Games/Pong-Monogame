using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.Objects
{
    public interface IObject : IUpdate, IDraw
    {
        Vector2 Position { get; set; }
        Vector2 Size { get; set; }
    }
}
