using System;
using Elementary;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class PowerAttackMechanics : MonoBehaviour
    {
        [SerializeField] private ActivationBehaviour _knifeActive;
        [SerializeField] private ActivationBehaviour _swordActive;

        [SerializeField] private IntBehaviour _powerHit;
        [SerializeField] private int _knifeHit;
        [SerializeField] private int _swordHit;

        private void OnEnable()
        {
            _knifeActive.OnActivate += OnKnifeActivate;
            _swordActive.OnActivate += OnSwordActivate;
        }

        private void OnDisable()
        {
            _knifeActive.OnActivate -= OnKnifeActivate;
            _swordActive.OnActivate -= OnSwordActivate;
        }

        private void OnKnifeActivate()
        {
            _powerHit.Assign(_knifeHit);
        }

        private void OnSwordActivate()
        {
            _powerHit.Assign(_swordHit);
        }
    }
}