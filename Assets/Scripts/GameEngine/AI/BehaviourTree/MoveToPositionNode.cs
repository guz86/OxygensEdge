﻿using GameEngine.AI.Tasks;
using Modules.Entities;
using UnityEngine;

namespace GameEngine.AI.BehaviourTree
{
    public sealed class MoveToPositionNode : BehaviourNode, ITaskCallback
    {
        [SerializeField]
        private MoveTask moveTask;

        [Space, SerializeField]
        private Blackboard blackboard;

        [SerializeField, BlackboardKey]
        private string unitKey;

        [SerializeField, BlackboardKey]
        private string stoppingDistanceKey;

        [SerializeField, BlackboardKey]
        private string targetPositionKey;

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetPositionKey, out Vector3 movePosition))
            {
                this.Return(false);
                return;
            }
            
            this.moveTask.SetUnit(unit);
            this.moveTask.SetStoppingDistance(stoppingDistance);
            this.moveTask.SetTargetPosition(movePosition);
            this.moveTask.Do(callback: this);
        }

        protected override void OnAbort()
        {
            this.moveTask.Cancel();
        }

        void ITaskCallback.OnComplete(Task task, bool success)
        {
            this.Return(success);
        }
    }
}