using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    public class MenuManager : StateManager, IState, IUpdate, IDraw
    {
        public MenuManager(ContentManager Content) : base(Content)
        {
            // TODO MIGHT NOT BE NECESSARY SINCE PONG IS A SMALL GAME
            // BUT THIS COULD REPRESENT THE MAIN MENU AND THE DIFFERENT SCREENS (OPTIONS / CONTROLS / CREDITS)
        }

        public StateManager Manager { get; set; }
        IState IState.NextState { get; set; }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Unload()
        {
            throw new NotImplementedException();
        }

    }
}
