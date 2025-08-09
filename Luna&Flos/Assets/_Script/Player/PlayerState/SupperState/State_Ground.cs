using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Guagua.CoreSystem;

namespace Guagua.Nia
{
    public class State_Ground : PlayerState
    {

        protected int xInput;

        private bool JumpInput;
        private bool isGrounded;
        private bool AttackInput;
        private bool DashInput;


        public State_Ground(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

            player.JumpState.ResetJump();
            player.DashState.ResetCanDash();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            xInput = player.InputHandler.NormInputX;
            JumpInput = player.InputHandler.JumpInput;
            AttackInput = player.InputHandler.AttackInput;
            DashInput = player.InputHandler.DashInput;


            if (AttackInput)
            {
                stateMachine.ChangeState(player.AttackState);
            }
            else if (DashInput && player.DashState.CheckIfCanDash())
            {
                stateMachine.ChangeState(player.DashState);
            }
            else if (JumpInput && player.JumpState.canJump())
            {
                player.InputHandler.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }
            else if (!isGrounded)
            {
                player.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.InAirState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
