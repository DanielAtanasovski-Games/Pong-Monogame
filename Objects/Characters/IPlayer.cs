using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongMonogame.Objects.Characters;

namespace PongMonogame.Objects
{
    public interface IPlayer : ICollidableObject
    {
        Vector2 CalculateSize (CharacterSize size)
        {
            Vector2 retSize = Vector2.Zero;
            if (size == CharacterSize.Small)
            {
                retSize = new Vector2(10, 40);
            } else if (size == CharacterSize.Medium)
            {
                retSize = new Vector2(15, 50);
            } else if (size == CharacterSize.Large)
            {
                retSize = new Vector2(10, 40);
            }

            return retSize;
        }
        // TODO: Controls that will be passed in from menu (as user can change controls)
    }
}
