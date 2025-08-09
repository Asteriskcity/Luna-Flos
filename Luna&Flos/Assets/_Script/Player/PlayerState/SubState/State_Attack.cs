using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guagua.WeaponSystem;
using Guagua.CoreSystem;

namespace Guagua.Nia
{
    public class State_Attack : State_Ability
    {
        private Weapon weapon;

        public State_Attack(
            Player player,
            PlayerStateMachine stateMachine,
            PlayerData playerData,
            string animBoolName,
            Weapon weapon
        ) : base(player, stateMachine, playerData, animBoolName)
        {
            this.weapon = weapon;

            weapon.OnExit += ExitHandler;
            Stats.OnGetHit += weapon.HandleStopAttack;
        }

        public override void Enter()
        {
            base.Enter();

            weapon.Enter();
        }

        private void ExitHandler()
        {
            AnimationFinTrigger();
            isAbilityDone = true;
        }




    }
}
