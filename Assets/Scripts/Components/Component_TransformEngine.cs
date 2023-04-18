using GameEngine.Mechanics;
using GameEngine.Mechanics.Move;
using UnityEngine;

namespace Components
{
    public class Component_TransformEngine : MonoBehaviour
        // ,
        // IComponent_GetPosition,
        // IComponent_SetPosition,
        // IComponent_GetRotation,
        // IComponent_SetRotation,
        // IComponent_LookAtPosition
    {
        public Vector3 Position
        {
            get { return this.engine.WorldPosition; }
        }

        public Quaternion Rotation
        {
            get { return this.engine.WorldRotation; }
        }

        [SerializeField]
        private TransformEngine engine;

        public void SetPosition(Vector3 position)
        {
            this.engine.SetPosition(position);
        }

        public void SetRotation(Quaternion rotation)
        {
            this.engine.SetRotation(rotation);
        }

        public void LookAtPosition(Vector3 position)
        {
            this.engine.LookAtPosition(position);
        }
    }
}