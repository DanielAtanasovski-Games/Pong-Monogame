using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    public class CollisionEvent
    {
        ICollidableObject objectA;
        ICollidableObject objectB;
        public CollisionEvent(ICollidableObject objectA, ICollidableObject objectB)
        {
            this.objectA = objectA;
            this.objectB = objectB;
        }

        public bool ResolveEvent()
        {
            if (objectA.ObjectInBounds(objectB)){
                return false;
            } else
            {
                objectA.OnCollisionExit();
                objectB.OnCollisionExit();
                return true;
            }

        }

        public bool ContainsObjects(ICollidableObject objectA, ICollidableObject objectB)
        {
            if (this.objectA.Equals(objectA) || this.objectA.Equals(objectB))
            {
                if (this.objectB.Equals(objectB) || this.objectB.Equals(objectA))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
