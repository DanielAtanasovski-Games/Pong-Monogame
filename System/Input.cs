using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongMonogame.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.System
{
    public sealed class Input : IUpdate
    {
        public static readonly Input instance = new Input();

        // Delegates
        // Keys
        public delegate void keyDelegate(Keys keyInEvent);
  
        // Events
        public event keyDelegate KeyPressedEvent;
        public event keyDelegate KeyReleasedEvent;

        public List<Keys> KeysPressed { get; set; }


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Input()
        {
        }

        private Input()
        {
            KeysPressed = new List<Keys> (Keyboard.GetState().GetPressedKeys());
        }

        public void Update(GameTime gameTime)
        {
            List<Keys> latestState = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            if (latestState.Count != KeysPressed.Count)
            {
                if (latestState.Count < KeysPressed.Count)
                {
                    if (KeyReleasedEvent != null)
                    {
                        // Released a key
                        RaiseReleasedKeys(latestState);
                    }
                } else if (latestState.Count > KeysPressed.Count)
                {
                    if (KeyPressedEvent != null)
                    {
                        // Pressed a new key
                        RaisePressedKeys(latestState);
                    }
                }
            }
            KeysPressed = latestState;
        }

        private void RaiseReleasedKeys(List<Keys> latestState)
        {
            for (int i = 0; i < KeysPressed.Count; i++)
            {
                if (!latestState.Contains(KeysPressed[i]))
                {
                    KeyReleasedEvent(KeysPressed[i]);
                }
            }
        }

        private void RaisePressedKeys(List<Keys> latestState)
        {
            for (int i = 0; i < latestState.Count; i++)
            {
                if (!KeysPressed.Contains(latestState[i]))
                {
                    KeyPressedEvent(latestState[i]);
                }
            }
        }


    }
}
