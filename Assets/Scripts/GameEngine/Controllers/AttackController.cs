﻿using Components;
using GameElements;
using Gameplay;
using InputKeyboard;
using UnityEngine;

namespace GameEngine.Controllers
{
    public sealed class AttackController : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    { 
        private AttackInput _input;

        private IAttackComponent _attackComponent;

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            _input = context
                .GetService<AttackInput>();
            _attackComponent = context
                .GetService<HeroService>()
                .GetHero()
                .Get<IAttackComponent>();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _input.OnAttack += OnAttack;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _input.OnAttack -= OnAttack;
        }
        
        private void OnAttack()
        {
            _attackComponent.Attack();
        }

    }
}