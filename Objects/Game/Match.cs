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
using System.Diagnostics;


namespace PongMonogame.System
{
    class Match : IDraw, IUpdate, IState
    {
        public Background MatchBackground { get; set; }
        public Ball GameBall { get; set; }
        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }
        public StateManager Manager { get; set; }

        public Vector4 MatchSize { get; set; }

        public List<IObject> objectList = new List<IObject>();
        public List<CollisionEvent> ongoingCollisions = new List<CollisionEvent>();


        public Match(StateManager Manager)
        {
            this.Manager = Manager;
            MatchSize = new Vector4(4, 4, PongGame.Instance.Graphics.PreferredBackBufferWidth - 4, PongGame.Instance.Graphics.PreferredBackBufferHeight - 4);
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
            // Add Objects
            MatchBackground = new Background(objectList.Count,Vector2.Zero, new Vector2(PongGame.Instance.Graphics.PreferredBackBufferWidth, PongGame.Instance.Graphics.PreferredBackBufferHeight));
            objectList.Add(MatchBackground);
            // Players
            Player1 = new HumanPlayer(objectList.Count, this, new Vector2(20 + MatchSize.X, MatchSize.W / 2), CharacterSize.Small);
            objectList.Add(Player1);
            Player2 = new HumanPlayer(objectList.Count, this, new Vector2(MatchSize.Z - (20 + MatchSize.X), MatchSize.W / 2), CharacterSize.Small);
            objectList.Add(Player2);
            // Ball
            GameBall = new Ball(objectList.Count, this, new Vector2(MatchSize.Z / 2, MatchSize.W / 2), 5);
            objectList.Add(GameBall);
            // Adjust player positions  
            Player2.AdjustPlayerPosition(PlayerStartingPosition.Right);
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
            OngoingCollisionsCheck();

            foreach (IObject o in objectList)
            {
                o.Update(gameTime);
                CollisionCheck(o);

            }
        }

        // Generic Check
        private void CollisionCheck(IObject subject)
        {
            if (!(subject is ICollidableObject))
                return;

            for (int i = 0; i < objectList.Count; i++)
            {
                // Check if self
                if (subject.ID == objectList[i].ID)
                    continue;

                // Check if other is collidable
                if (!(objectList[i] is ICollidableObject))
                    continue;

                ICollidableObject collidableSubject = (ICollidableObject) subject;
                ICollidableObject otherObject = (ICollidableObject) objectList[i];

                if (collidableSubject.ObjectInBounds(otherObject))
                {
                    // Prevents from calling OnCollisionEnter Twice
                    if (CheckIfOngoing(collidableSubject, otherObject))
                        continue;

                    //Debug.WriteLine(collidableSubject.Tag + collidableSubject.ID + " Collided with " + otherObject.Tag + otherObject.ID);
                    //Debug.WriteLine(collidableSubject.Position + ", " + otherObject.Position);

                    // Call Methods
                    collidableSubject.OnCollisionEnter(otherObject);
                    otherObject.OnCollisionEnter(collidableSubject);

                    ongoingCollisions.Add(new CollisionEvent(collidableSubject, otherObject));
                }

            }
        }

        private bool CheckIfOngoing(ICollidableObject a, ICollidableObject b)
        {
            for (int i = 0; i < ongoingCollisions.Count; i++)
            {
                if (ongoingCollisions[i].ContainsObjects(a, b))
                    return true;
            }

            return false;
        }

        //// Check on particular layer / circumstance
        //private void CollisionCheck(ICollidableObject subject, List<ICollidableObject> layer)
        //{
        //    for (int i = 0; i < layer.Count; i++)
        //    {
        //        // Check if self
        //        if (subject.Equals(layer[i]))
        //            continue;

        //        if (subject.ObjectInBounds(layer[i]))
        //        {

        //            // Call Methods
        //            subject.OnCollisionEnter();
        //            layer[i].OnCollisionEnter();

        //            ongoingCollisions.Add(new CollisionEvent(subject, layer[i]));

        //        }

        //    }
        //}

        // Check all ongoing Collisions
        private void OngoingCollisionsCheck()
        {
            for (int i = 0; i < ongoingCollisions.Count; i++)
            {
                if (ongoingCollisions[i].ResolveEvent())
                {
                    ongoingCollisions.RemoveAt(i);
                }
            }
        }

        public bool ValidPosition(ICollidableObject obj, int speed)
        {
            Vector2 newPos = new Vector2(obj.Position.X, obj.Position.Y + speed);
            // Check Object
            //for (int i = 0; i < objectList.Count; i++)
            //{
            //    if (objectList[i].ID == obj.ID)
            //        continue;

            //    if (objectList[i] is ICollidableObject)
            //    {
            //        ICollidableObject collidable = (ICollidableObject)objectList[i];
            //        if (collidable.ObjectInBounds(newPos, obj.Size))
            //        {
            //            return false;
            //        }
            //    }
            //}

            if (!InBounds(newPos, obj.Size))
            {
                return false;
            }

            return true;
        }

        //public bool ValidPosition(IObject obj)
        //{
        //    // Check Object
        //    for (int i = 0; i < objectList.Count; i++)
        //    {
        //        if (objectList[i].ID == obj.ID)
        //            continue;

        //        if (objectList[i] is ICollidableObject)
        //        {
        //            ICollidableObject collidable = (ICollidableObject)objectList[i];
        //            if (collidable.ObjectInBounds(obj.Position, obj.Size))
        //            {
        //                return false;
        //            }
        //        }
        //    }

        //    if (!InBounds(obj.Position, obj.Size))
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        public bool ValidPosition(int ID, Vector2 position, Vector2 size, int speed)
        {
            Vector2 newPos = new Vector2(position.X, position.Y + speed);
            // Check Object
            //for (int i = 0; i < objectList.Count; i++)
            //{
            //    if (objectList[i].ID == ID)
            //        continue;

            //    if (objectList[i] is ICollidableObject)
            //    {
            //        ICollidableObject collidable = (ICollidableObject)objectList[i];
            //        if (collidable.ObjectInBounds(newPos, size))
            //        {
            //            return false;
            //        }
            //    }
            //}

            if (!InBounds(newPos, size))
            {
                return false;
            }

            return true;
        }

        private bool InBounds(Vector2 Position, Vector2 Size)
        {
            if (Position.X < MatchSize.X || (Position.X + Size.X) > MatchSize.Z)
            {
                return false;
            }

            if (Position.Y < MatchSize.Y || (Position.Y + Size.Y) > MatchSize.W)
            {
                return false;
            }

            return true;
        }

        private bool InBounds(Vector2 Position)
        {
            if (Position.X < MatchSize.X || Position.X > MatchSize.Z)
            {
                return false;
            }

            if (Position.Y < MatchSize.Y || Position.Y > MatchSize.W)
            {
                return false;
            }

            return true;
        }

    }
}
