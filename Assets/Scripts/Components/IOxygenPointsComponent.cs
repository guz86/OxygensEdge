using System;

namespace Components
{
    public interface IOxygenPointsComponent
    {
        event Action<int> OnOxygenPointsChanged;
        void SetOxygenPoints(int hitPoints);
        void SetMaxOxygenPoints(int hitPoints);
        void FullOxygenPoints();
        int OxygenPoints { get; }
        int MaxOxygenPoints { get; }
    }
} 