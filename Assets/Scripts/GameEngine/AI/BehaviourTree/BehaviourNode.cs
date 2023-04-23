﻿using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.AI.BehaviourTree
{
    public abstract class BehaviourNode : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        public bool IsRunning
        {
            get { return this.isRunning; }
        }

        private bool isRunning;

        private ICallback callback;

        [Button]
        public void Run(ICallback callback)
        {
            if (this.isRunning)
            {
                Debug.LogWarning($"Node {this.name} is already running!");
                return;
            }

            this.callback = callback;
            this.isRunning = true;
            this.Run();
        }

        [Button]
        public void Abort()
        {
            if (this.isRunning)
            {
                Debug.Log($"ABORT NODE {name}");
                this.callback = null;
                this.isRunning = false;
                this.OnAbort();
            }
        }

        protected void Return(bool success)
        {
            if (!this.isRunning)
            {
                return;
            }

            this.isRunning = false;
            Debug.Log($"RETURN NODE {name}: {success}");

            var callback = this.callback;
            if (callback != null)
            {
                this.callback = null;
                callback.Invoke(this, success);
            }
        }

        protected abstract void Run();

        protected virtual void OnAbort()
        {
        }

        public interface ICallback
        {
            void Invoke(BehaviourNode node, bool success);
        }
    }
}