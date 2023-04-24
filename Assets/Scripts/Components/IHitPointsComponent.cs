using System;

namespace Components
{
    public interface IHitPointsComponent
    {
        event Action<int> OnHitPointsChanged;
        void SetHitPoints(int hitPoints);
        void SetMaxHitPoints(int hitPoints);
        int HitPoints { get; }
        int MaxHitPoints { get; }
    }
}