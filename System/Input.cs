using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    public sealed class Input : IUpdate
    {
        public static readonly Input instance = new Input();

        public Keys KeysPressed { get; set; }


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Input()
        {
        }

        private Input()
        {
        }

        public void Update(GameTime gameTime)
        {
                throw new NotImplementedException();
        }
    }
}
