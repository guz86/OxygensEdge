using System;
using System.Runtime.Serialization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class BoolAdapter
    {
        public bool Value
        {
            get { return this.GetValue(); }
        }

        [SerializeField]
        private Mode mode;

        [ShowIf("mode", Mode.BASE)]
        [SerializeField]
        private bool baseValue;

        [ShowIf("mode", Mode.MONO_BEHAVIOUR)]
        [OptionalField]
        [SerializeField]
        private BoolBehaviour monoValue;

        [ShowIf("mode", Mode.SCRIPTABLE_OBJECT)]
        [OptionalField]
        [SerializeField]
        private ScriptableBool scriptableValue;

        private bool GetValue()
        {
            return this.mode switch
            {
                Mode.BASE => this.baseValue,
                Mode.MONO_BEHAVIOUR => this.monoValue.Value,
                Mode.SCRIPTABLE_OBJECT => this.scriptableValue.value,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        private enum Mode
        {
            BASE = 0,
            MONO_BEHAVIOUR = 1,
            SCRIPTABLE_OBJECT = 2
        }
    }
}