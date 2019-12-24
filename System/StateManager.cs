using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    //public enum GAMESTATE
    //{
    //    MAINMENU, // PLAY AND QUIT
    //    GAMEMENU, // SET 1v1 or 1vCPU
    //    MATCH, // ACTUAL GAME
    //    STATS // END RESULTS AND REMATCH OPTION AND QUIT TO MAINMENU
    //}

    public abstract class StateManager : IUpdate, IDraw
    {
        public IState CurrentState { get; set; }
        public ContentManager Content;

        public StateManager(ContentManager Content) 
        {
            this.Content = Content;
        }
        
        public StateManager(ContentManager Content, IState currentState)
        {
            this.Content = Content;
            this.CurrentState = currentState;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            DrawCurrentState(spriteBatch);
        }

        public virtual void Update(GameTime gameTime)
        {
            UpdateCurrentState(gameTime);
        }

        public virtual void NextState()
        {
            IState nextState = CurrentState.NextState;
            CurrentState.Unload();

            CurrentState = nextState;
            LoadCurrentState();
        }
         
        //public void NextState(IState nextState)
        //{
        //    if (!currentState.NextState.Contains(nextState))
        //    { 
        //        throw new NotImplementedException();
        //    }

        //    IState newState = currentState.nextState.Find(x => x == nextState);
        //    currentState.Unload();

        //    currentState = newState;
        //    LoadCurrentState();
        //}

        public virtual void LoadCurrentState()
        {
            CurrentState.Load();
            // Call the initialiser after all content loaded for state
            InitCurrentState();
        }

        private void InitCurrentState()
        {
            CurrentState.Init();
        }

        private void DrawCurrentState(SpriteBatch spriteBatch)
        {
            CurrentState.Draw(spriteBatch);
        }

        private void UpdateCurrentState(GameTime gameTime)
        {
            CurrentState.Update(gameTime);
        }

        private void UnloadCurrentState()
        {
            CurrentState.Unload();
        }
    }
}
