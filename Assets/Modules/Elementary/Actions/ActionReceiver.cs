using System;
using System.Collections.Generic;
using Elementary;
using Sirenix.OdinInspector;

namespace Elementary
{
    [Serializable]
    public sealed class ActionReceiver
    {
        public event Action OnEvent;

        [ReadOnly]
        [ShowInInspector]
        private readonly List<IAction> handlers;

        public ActionReceiver()
        {
            this.handlers = new List<IAction>();
        }

        public void AddHandler(IAction handler)
        {
            this.handlers.Add(handler);
        }

        public void RemoveHandler(IAction handler)
        {
            this.handlers.Remove(handler);
        }

        public void Call()
        {
            for (int i = 0, count = this.handlers.Count; i < count; i++)
            {
                var handler = this.handlers[i];
                handler.Do();
            }

            this.OnEvent?.Invoke();
        }
    }

    [Serializable]
    public sealed class ActionReceiver<T>
    {
        public event Action<T> OnEvent;

        [ReadOnly]
        [ShowInInspector]
        private readonly List<IAction<T>> handlers;

        public ActionReceiver()
        {
            this.handlers = new List<IAction<T>>();
        }

        public void AddHandler(IAction<T> handler)
        {
            this.handlers.Add(handler);
        }

        public void RemoveHandler(IAction<T> handler)
        {
            this.handlers.Remove(handler);
        }

        public void Call(T value)
        {
            for (int i = 0, count = this.handlers.Count; i < count; i++)
            {
                var handler = this.handlers[i];
                handler.Do(value);
            }

            this.OnEvent?.Invoke(value);
        }
    }
}