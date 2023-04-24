using System;
using GameElements;
using UnityEngine;

namespace GameEngine.Controllers
{
    public class OxygenInput : MonoBehaviour,
        IGameStartElement,
        IGameFinishElement
    {
        public event Action OnOxygen;
        
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnOxygen?.Invoke();
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