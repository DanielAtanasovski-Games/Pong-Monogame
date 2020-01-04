using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.Objects
{
    public interface IContent
    {
        void Load(ContentManager Content);
        void Unload(ContentManager Content);
    }
}
