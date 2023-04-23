using System.Collections.Generic;
using UnityEngine;

namespace GameEngine.AI.BehaviourTree
{
    public sealed class AssignMovePositionNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string waypointsKey;

        [BlackboardKey]
        [SerializeField]
        private string movePositionKey;
    
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.waypointsKey, out IEnumerator<Vector3> waypoints))
            {
                this.Return(false);
                return;
            }

            if (this.blackboard.HasVariable(this.movePositionKey))
            {
                this.blackboard.ChangeVariable(this.movePositionKey, waypoints.Current);
            }
            else
            {
                this.blackboard.AddVariable(this.movePositionKey, waypoints.Current);
            }
            
            this.Return(true);
        }
    }
}