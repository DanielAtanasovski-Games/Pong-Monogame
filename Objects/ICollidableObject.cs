using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.Objects
{
    public interface ICollidableObject : IObject
    {
        // FACT: Rectangles are considered Collidable in this game
        // Checks a Particular Point
        bool PositionInBounds(Vector2 otherPosition)
        {
            if (otherPosition.X < (Position.X + Size.X) && otherPosition.X > Position.X)
            {
                if (otherPosition.Y < (Position.Y + Size.Y) && otherPosition.Y > Position.Y)
                {
                    return true;
                }
            }
            return false;
        }

        // Takes whole boundary into consideration
        bool ObjectInBounds(Vector2 otherPosition, Vector2 otherSize)
        {
            // Right or Left
            if (otherPosition.X > (Position.X + Size.X) || (otherPosition.X + otherSize.X) < Position.X)
            {
                return false;
            }

            // Above or below
            if (otherPosition.Y > (Position.Y + Size.Y) || (otherPosition.Y + otherSize.Y) < Position.Y)
            {
                return false;
            }

            return true;
        }

        bool ObjectInBounds(Rectangle otherRec)
        {
            Vector2 otherPosition = new Vector2(otherRec.X, otherRec.Y);
            Vector2 otherSize = new Vector2(otherRec.Width, otherRec.Height);
            // Right or Left
            if (otherPosition.X > (Position.X + Size.X) || (otherPosition.X + otherSize.X) < Position.X)
            {
                return false;
            }

            // Above or below
            if (otherPosition.Y > (Position.Y + Size.Y) || (otherPosition.Y + otherSize.Y) < Position.Y)
            {
                return false;
            }

            return true;
        }

        bool ObjectInBounds(ICollidableObject otherObject)
        {
            return ObjectInBounds(otherObject.Position, otherObject.Size);
        }

        void OnCollisionEnter(ICollidableObject other);
        void OnCollisionExit(ICollidableObject other);
    }
}
