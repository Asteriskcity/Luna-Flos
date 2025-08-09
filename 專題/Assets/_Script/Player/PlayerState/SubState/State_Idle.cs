using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Nia
{
    public class State_Idle : State_Ground
    {
        public State_Idle(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            Movement.Rb.isKinematic = true;
        }

        public override void Exit()
        {
            base.Exit();

            Movement.Rb.isKinematic = false;
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
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Movement.SetVelocityZero();
        }
    }
}

