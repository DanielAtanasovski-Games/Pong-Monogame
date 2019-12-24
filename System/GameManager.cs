using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Pong_Monogame;
using PongMonogame.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    class GameManager : StateManager
    {
        public GameManager(ContentManager Content, GraphicsDeviceManager graphics) : base(Content)
        {
            CurrentState = new Menu(graphics, this);
        }
    }
}
