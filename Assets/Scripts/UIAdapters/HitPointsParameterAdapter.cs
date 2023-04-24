using Components;
using GameElements;
using Gameplay;
using Modules.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UIAdapters
{
    //ADAPTER
    public sealed class HitPointsParameterAdapter : MonoBehaviour,
    IGameReadyElement,
    IGameStartElement,
    IGameFinishElement
    { 
        [SerializeField] private Image progressBar;

        private IEntity _character;
        private int _maxHitPoints;
        private int _currentPoints;

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            _character = context.GetService<HeroService>().GetHero();

            SetupPanel();
        }

        private void SetupPanel()
        {
            _maxHitPoints = _character.Get<IHitPointsComponent>().MaxHitPoints;
            _currentPoints = _character.Get<IHitPointsComponent>().HitPoints;
            UpdatePanel(_currentPoints);
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _character.Get<IHitPointsComponent>().OnHitPointsChanged += this.UpdatePanel;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _character.Get<IHitPointsComponent>().OnHitPointsChanged -= this.UpdatePanel;
        }

        private void UpdatePanel(int current)
        {
            this.progressBar.fillAmount = (float) current / _maxHitPoints;
        }
    }
}