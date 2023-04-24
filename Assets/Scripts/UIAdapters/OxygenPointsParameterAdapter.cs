using Components;
using GameElements;
using Gameplay;
using Modules.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UIAdapters
{
    public class OxygenPointsParameterAdapter : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    { 
        [SerializeField] private Image _progressBar;

        private IEntity _character;
        private int _maxOxyPoints;
        private int _currentOxyPoints;

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            _character = context.GetService<HeroService>().GetHero();

            SetupPanel();
        }

        private void SetupPanel()
        {
            _maxOxyPoints = _character.Get<IOxygenPointsComponent>().MaxOxygenPoints;
            _currentOxyPoints = _character.Get<IOxygenPointsComponent>().OxygenPoints;
            UpdatePanel(_currentOxyPoints);
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            _character.Get<IOxygenPointsComponent>().OnOxygenPointsChanged += this.UpdatePanel;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _character.Get<IOxygenPointsComponent>().OnOxygenPointsChanged -= this.UpdatePanel;
        }

        private void UpdatePanel(int current)
        {
            _progressBar.fillAmount = (float) current / _maxOxyPoints;
        }
    }
}