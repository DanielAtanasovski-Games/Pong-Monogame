using Microsoft.Xna.Framework.Content;
using PongMonogame.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.Objects
{
    public interface IState : IUpdate, IDraw, IContent
    {
        StateManager Manager { get; set; }
        void Init();
    }
}
