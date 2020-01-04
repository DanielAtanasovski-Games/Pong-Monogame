using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Pong_Monogame;
using PongMonogame.GUI;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    class GameManager : StateManager
    {
        // Manages the whole game / app
        public StateManager Manager { get; set; }

        public GameManager(ContentManager Content) : base(Content)
        {
            CurrentState = new MenuManager(Content, this);
        }

    }
}
