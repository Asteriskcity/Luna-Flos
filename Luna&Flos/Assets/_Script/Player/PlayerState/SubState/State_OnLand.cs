using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Nia
{
    public class State_OnLand : State_Ground
    {
        public State_OnLand(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Movement.SetVelocityZero();
            ParticleManager.StartParticles(playerData.LandDust, ParticleManager.LandDust.position, player.transform.rotation);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                if (xInput != 0)
                {
                    stateMachine.ChangeState(player.MoveState);
                }
                else if (isAnimationFinished)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
            }
        }
    }
}
