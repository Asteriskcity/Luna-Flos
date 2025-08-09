using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Nia
{
    public class State_Jump : State_Ability
    {

        private int LeftJumpTimes;

        public State_Jump(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
            LeftJumpTimes = AmountOfJump;
        }

        public override void Enter()
        {
            base.Enter();

            Movement?.SetVelocityY(playerData.jumpforce);
            LeftJumpTimes--;
            player.InAirState.SetisJumping();
            isAbilityDone = true;
        }

        public bool canJump()
        {
            if (LeftJumpTimes > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetJump() => LeftJumpTimes = AmountOfJump;

        public void DecreaseJump() => LeftJumpTimes--;
    }
}

