using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong_Monogame;
using PongMonogame.GUI.Elements;
using PongMonogame.Objects;
using PongMonogame.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.GUI
{
    public abstract class Menu : IUpdate, IDraw, IContent, IState
    {
        // TODO: UPDATE THIS TO USE STATES!
        // MAIN MENU -> GAME SETTINGS MENU -> GAME -> MATCH RESULTS / STATS / REMATCH
        // EACH A DIFFERENT CLASS
        // MENU -> MENU -> MATCH -> MENU

        // Options
        private protected Vector2 middlePoint;
        private protected List<Selection> menuOptions;
        private protected int selection = 0;

        // Input Keys
        public List<Keys> UP_KEYS = new List<Keys>() { Keys.Up, Keys.W };
        public List<Keys> DOWN_KEYS = new List<Keys>() { Keys.Down, Keys.S };
        public List<Keys> ENTER_KEYS = new List<Keys>() { Keys.Enter, Keys.Space };

        public StateManager Manager { get; set; }

        public Menu(StateManager Manager)
        {
            this.Manager = Manager;
            middlePoint = new Vector2(PongGame.Instance.Graphics.PreferredBackBufferWidth / 2, PongGame.Instance.Graphics.PreferredBackBufferHeight / 2);
        }

        public abstract void Load(ContentManager Content);

        public abstract void Init();

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        public abstract void Unload(ContentManager Content);

        private protected virtual void GetMenuMovement(Keys key)
        {
            if (UP_KEYS.Contains(key)){
                MoveUp();
            } else if (DOWN_KEYS.Contains(key))
            {
                MoveDown();
            } else if (ENTER_KEYS.Contains(key))
            {
                Select();
            }
        }

        private protected virtual void DrawOptions(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < menuOptions.Count; i++)
            {
                menuOptions[i].SelectionNum = i;
                menuOptions[i].Draw(spriteBatch);
            }
        }

        // Menu
        private protected virtual void MoveUp()
        {
            // Check if we're the top option
            if (selection <= 0)
                return;
            // Update
            menuOptions[selection].Selected = false;
            selection--;
            menuOptions[selection].Selected = true;
        }

        private protected virtual void MoveDown()
        {
            // Check if we're the bottom option
            if (selection >= menuOptions.Count-1)
                return;
            // Update
            menuOptions[selection].Selected = false;
            selection++;
            menuOptions[selection].Selected = true;
        }

        private protected virtual void Select()
        {
            menuOptions[selection].Callback();
        }
    }
}
