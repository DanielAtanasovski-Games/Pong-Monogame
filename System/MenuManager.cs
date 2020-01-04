using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using PongMonogame.GUI;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    public class MenuManager : StateManager, IState, IUpdate, IDraw
    {
        // Handles (TitleScreen ?) -> MainMenu -> Game Options
        public StateManager Manager { get; set; }
        private MainMenu mainMenu;

        public MenuManager(ContentManager Content, StateManager Manager) : base(Content)
        {
            this.Manager = Manager;

            mainMenu = new MainMenu(this);
            CurrentState = mainMenu;
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
