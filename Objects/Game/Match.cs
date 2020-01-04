using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong_Monogame;
using Pong_Monogame.Objects;
using PongMonogame.Objects;
using PongMonogame.Objects.Characters;
using PongMonogame.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    class Match : IDraw, IUpdate, IState
    {
        public Background MatchBackground { get; set; }
        public Ball GameBall { get; set; }
        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }
        public StateManager Manager { get; set; }
        public List<IObject> objectList = new List<IObject>();

        public Match(StateManager Manager)
        {
            this.Manager = Manager;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IObject o in objectList)
            {
                o.Draw(spriteBatch);
            }
        }

        public void Init()
        {
            MatchBackground = new Background(Vector2.Zero, new Vector2(PongGame.Instance.Graphics.PreferredBackBufferWidth, PongGame.Instance.Graphics.PreferredBackBufferHeight));
            Player1 = new HumanPlayer(new Vector2(10, PongGame.Instance.Graphics.PreferredBackBufferHeight / 2), CharacterSize.Small);
            Player2 = new HumanPlayer(new Vector2((PongGame.Instance.Graphics.PreferredBackBufferWidth) - 20, PongGame.Instance.Graphics.PreferredBackBufferHeight / 2), CharacterSize.Small);
            objectList.Add(MatchBackground);
            objectList.Add(Player1);
            objectList.Add(Player2);
        }

        public void Load(ContentManager Content)
        {
            foreach (IObject o in objectList)
            {
                o.Load(Manager.Content);
            }
            
        }

        public void Unload(ContentManager Content)
        {
            foreach (IObject o in objectList)
            {
                o.Unload(Manager.Content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IObject o in objectList)
            {
                o.Update(gameTime);
            }
        }
    }
}
