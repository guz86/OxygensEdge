using System.Collections.Generic;
using UnityEngine;

namespace GameEngine.AI.BehaviourTree
{
    public sealed class NextWaypointNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string waypointsIteratorKey;
    
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.waypointsIteratorKey, out IEnumerator<Vector3> iterator))
            {
                this.Return(false);
                return;
            }

            iterator.MoveNext();
            this.Return(true);
        }
    }
}