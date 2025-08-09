using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnFinish;
        public event Action OnStartmovement;
        public event Action OnStopMovement;
        public event Action OnBackMovement;
        public event Action OnFrontMovement;
        public event Action OnAttackAction;
        public event Action OnFireAction;

        private void AnimationFinTrigger() => OnFinish?.Invoke();
        private void StartMovementTrigger() => OnStartmovement?.Invoke();
        private void StopmovementTrigger() => OnStopMovement?.Invoke();
        private void BackMovementTrigger() => OnBackMovement?.Invoke();
        private void FrontMovementTrigger() => OnFrontMovement?.Invoke();
        private void AttackActionTrigger() => OnAttackAction?.Invoke();
        private void FireActionTrigger() => OnFireAction?.Invoke();
    }
}

