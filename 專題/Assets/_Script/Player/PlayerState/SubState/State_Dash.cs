using UnityEngine;
using Guagua.CoreSystem;

namespace Guagua.Nia
{
    public class State_Dash : State_Ability
    {

        public bool CanDash { get; private set; }

        private float originalgravity;
        private float LastDashtime;

        private Vector2 direction;

        public State_Dash(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            CanDash = false;
            originalgravity = Movement.Rb.gravityScale;
            Movement.Rb.gravityScale = 0;

            direction = new(Movement.FacingDirection, 0);
        }

        public override void Exit()
        {
            base.Exit();

            Movement.Rb.gravityScale = originalgravity;
            isAbilityDone = true;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (Time.time >= StarTime + playerData.DashTime)
            {
                Movement.Rb.gravityScale = originalgravity;
                isAbilityDone = true;
                LastDashtime = Time.time;
            }
            else
            {
                Movement?.SetVelocity(playerData.DashPower, direction);
            }
        }

        public bool CheckIfCanDash()
        {
            return CanDash && Time.time >= LastDashtime + playerData.DashCD;
        }

        public void ResetCanDash() => CanDash = true;



    }
}



