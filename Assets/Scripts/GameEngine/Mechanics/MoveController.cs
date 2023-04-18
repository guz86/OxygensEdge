using Components;
using GameElements;
using GameEngine.Controllers;
using Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class MoveController : MonoBehaviour,
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        [ReadOnly]
        [ShowInInspector]
        private KeyboardInput input;

        [ReadOnly]
        [ShowInInspector]
        private IComponent_MoveInDirection heroMoveComponent;

        void IGameInitElement.InitGame(IGameContext context)
        {
            this.input = context.GetService<KeyboardInput>();
            this.heroMoveComponent = context
                .GetService<HeroService>()
                .GetHero()
                .Get<IComponent_MoveInDirection>();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            this.input.OnDirectionMoved += this.OnDirectionMoved;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            this.input.OnDirectionMoved -= this.OnDirectionMoved;
        }

        private void OnDirectionMoved(Vector3 direction)
        {
            this.heroMoveComponent.Move(direction);
        }
    }
}