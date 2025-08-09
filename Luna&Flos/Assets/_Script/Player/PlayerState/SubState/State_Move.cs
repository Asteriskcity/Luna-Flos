using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Nia
{
    public class State_Move : State_Ground
    {
        public State_Move(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement?.CheckWhenToFlip(xInput);

            if (!isExitingState)
            {
                if (xInput == 0)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Movement?.SetVelocityX(playerData.movespeed * xInput);
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();

            ParticleManager.StartParticles(playerData.MoveDust, ParticleManager.MoveDust.position, player.transform.rotation);
        }
    }

}
