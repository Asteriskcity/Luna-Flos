using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class B_Move : MoveState
    {
        private EnemyB enemy;

        public B_Move(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyB enemy) : base(entity, stateMachine, enemiesData, animBoolName)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isDetectedplayer)
            {
                stateMachine.ChangeState(enemy.detectedstate);
            }
            else if (isMovingTimesup)
            {
                stateMachine.ChangeState(enemy.idlestate);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Movement.SetVelocityX(enemiesData.movespeed * Movement.FacingDirection);
        }
    }
}
