using System;

namespace GameEngine.Mechanics
{
    public interface ISendDeathComponent
    {
        event Action OnDied;
        
        void Die();
    }
}