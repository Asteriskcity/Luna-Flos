using System;
using System.Collections;
using System.Collections.Generic;
using Guagua.CoreSystem;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class Movement : WeaponComponent<MovementData, AttackMovement>
    {

        private CoreSystem.Movement movement;

        protected override void Start()
        {
            base.Start();

            movement = Core.GetCoreComponent<CoreSystem.Movement>();

            EventHandler.OnStartmovement += HandleStartMovement;
            EventHandler.OnStopMovement += HanedleStopMovement;
            EventHandler.OnBackMovement += HandleBackMovement;
            EventHandler.OnFrontMovement += HandleFrontMovement;
        }

        private void HandleFrontMovement()
        {
            movement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, movement.FacingDirection);
        }

        private void HandleBackMovement()
        {
            movement.SetVelocityX(-currentAttackData.Velocity * movement.FacingDirection);
        }

        private void HandleStartMovement()
        {
            if (inputHandler.NormInputX != 0)
                movement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, movement.FacingDirection);
        }

        private void HanedleStopMovement()
        {
            movement.SetVelocityZero();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            EventHandler.OnStartmovement -= HandleStartMovement;
            EventHandler.OnStopMovement -= HanedleStopMovement;
        }
    }
}
