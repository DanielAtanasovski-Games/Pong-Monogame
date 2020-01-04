using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.Objects;
using System;

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
        public IState PreviousState { get; set; }
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
            throw new NotImplementedException();
        }

        public virtual void NextState(IState nextState)
        {
            //if (!CurrentState.NextState.Contains(nextState))
            //{
            //    throw new NotImplementedException();
            //}

            //IState newState = CurrentState.nextState.Find(x => x == nextState);
            CurrentState.Unload(Content);

            CurrentState = nextState;
            LoadCurrentState();
        }

        public virtual void LoadCurrentState()
        {
            CurrentState.Load(Content);
            // Call the initialiser after all content loaded for state
            InitCurrentState();
        }

        public virtual void UnloadCurrentState()
        {
            CurrentState.Unload(Content);
        }

        private protected virtual void InitCurrentState()
        {
            CurrentState.Init();
        }

        private protected virtual void DrawCurrentState(SpriteBatch spriteBatch)
        {
            CurrentState.Draw(spriteBatch);
        }

        private protected virtual void UpdateCurrentState(GameTime gameTime)
        {
            CurrentState.Update(gameTime);
        }

        
    }
}
