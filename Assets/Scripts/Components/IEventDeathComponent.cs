using System;

namespace Components
{
    public interface IEventDeathComponent
    {
        event Action OnDied;
    }
}