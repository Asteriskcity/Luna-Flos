using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Guagua.CoreSystem;

namespace Guagua.Nia
{
    public class State_InAir : PlayerState
    {

        private int xInput;

        private bool isGrounded;
        private bool JumpInput;
        private bool JumpInputStop;
        private bool CoyoteTime;  //郊狼時間
        private bool isJumping;
        private bool AttackInput;
        private bool SwitchInput;
        private bool DashInput;

        public State_InAir(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CheckCoyoteTime();

            xInput = player.InputHandler.NormInputX;
            JumpInput = player.InputHandler.JumpInput;
            JumpInputStop = player.InputHandler.JumpInputStop;
            AttackInput = player.InputHandler.AttackInput;
            DashInput = player.InputHandler.DashInput;


            CheckMultiplier();

            if (AttackInput)
            {
                stateMachine.ChangeState(player.AttackState);
            }
            else if (DashInput && player.DashState.CheckIfCanDash())
            {
                stateMachine.ChangeState(player.DashState);
            }
            else if (isGrounded && Movement?.CurrentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.OnLandState);
            }
            else if (JumpInput && player.JumpState.canJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else
            {
                Movement?.CheckWhenToFlip(xInput);
                Movement?.SetVelocityX(playerData.movespeed * xInput);

                player.Anim.SetFloat("VelocityX", Mathf.Abs(Movement.CurrentVelocity.x));
                player.Anim.SetFloat("VelocityY", Movement.CurrentVelocity.y);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckCoyoteTime()
        {
            if (CoyoteTime && Time.time > StarTime + playerData.coyoteTime)
            {
                CoyoteTime = false;
                player.JumpState.DecreaseJump();
            }
        }

        private void CheckMultiplier()
        {
            if (isJumping)
            {
                if (JumpInputStop)
                {
                    Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.VariableJumpHeight);
                    isJumping = false;
                }
                else if (Movement?.CurrentVelocity.y <= 0f)
                {
                    isJumping = false;
                }
            }
        }

        public void StartCoyoteTime() => CoyoteTime = true;

        public void SetisJumping() => isJumping = true;

    }
}

