using PongMonogame.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace PongMonogame.Objects
{
    public interface IState : IUpdate, IDraw
    {
        StateManager Manager { get; set; }
        IState NextState { get; set; }
        void Init();
        void Load();
        void Unload();
    }
}
