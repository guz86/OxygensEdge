using System;
using GameElements;
using UnityEngine;

namespace GameEngine.Controllers
{
    public class KeyboardInput : MonoBehaviour,
        IGameStartElement,
        IGameFinishElement
    {
        public event Action<Vector3> OnDirectionMoved;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            HandleKeyboard();
        }
    
        private void HandleKeyboard()
        {
            /*if (Input.GetKey(KeyCode.W))
            {
                this.Move(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.Move(Vector3.back);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.Move(Vector3.right);
            }*/
            
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            var moveDirection = new Vector3(horizontal, 0, vertical);
            this.Move(moveDirection);
        }

        private void Move(Vector3 direction)
        {
            this.OnDirectionMoved?.Invoke(direction);
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            enabled = true;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            enabled = false;
        }
    }
}