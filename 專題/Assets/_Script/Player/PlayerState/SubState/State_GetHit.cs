using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Nia
{
    public class State_GetHit : PlayerState
    {
        public State_GetHit(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }


        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= StarTime + playerData.StunTime)
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }

        public override void Exit()
        {
            base.Exit();

            Movement.CanSetVelocity = true;
        }

    }
}

