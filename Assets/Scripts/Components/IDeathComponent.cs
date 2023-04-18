using System;

namespace Components
{
    public interface IDeathComponent
    {
        event Action OnDied;
    }
}