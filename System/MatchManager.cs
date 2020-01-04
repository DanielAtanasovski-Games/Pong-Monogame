using Microsoft.Xna.Framework.Content;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    class MatchManager : StateManager, IState
    {
        // Handles Match Settings -> Match -> End of Match Stats
        public StateManager Manager { get; set; }

        Match match;

        public MatchManager(ContentManager Content, StateManager Manager) : base(Content)
        {
            this.Manager = Manager;

            match = new Match(this);
            CurrentState = match;
        }

        public void Init()
        {
        }

        public void Load(ContentManager Content) 
        {
            LoadCurrentState();
        }

        public void Unload(ContentManager Content)
        {
            UnloadCurrentState();
        }
    }
}
