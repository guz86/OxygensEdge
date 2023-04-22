using System;
using GameElements;
using UnityEngine;

namespace InputKeyboard
{
    public class AttackInput : MonoBehaviour,
        IGameStartElement,
        IGameFinishElement
    {
        public event Action OnAttack;
        
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnAttack?.Invoke();
            }
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