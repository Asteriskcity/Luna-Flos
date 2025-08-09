using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guagua.CoreSystem;

namespace Guagua.Nia
{
    public class State_Ability : PlayerState
    {

        protected int AmountOfJump = 1;

        protected bool isAbilityDone;

        private bool isGrounded;

        public State_Ability(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            if (CollisionSenses)
            {
                isGrounded = CollisionSenses.Ground();
            }

        }

        public override void Enter()
        {
            base.Enter();

            isAbilityDone = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (playerData.DoubleJump) { AmountOfJump = 2; } else if (!playerData.DoubleJump) { AmountOfJump = 1; } //TODO:測試結束後刪掉後面

            if (isAbilityDone)
            {
                if (isGrounded && Movement?.CurrentVelocity.y < 0.01f)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
                else
                {
                    stateMachine.ChangeState(player.InAirState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


    }
}

