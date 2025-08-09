using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class B_GetHit : GetHitState
    {
        private EnemyB enemy;

        public B_GetHit(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyB enemy) : base(entity, stateMachine, enemiesData, animBoolName)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= startTime + enemiesData.stunTime)
            {
                stateMachine.ChangeState(enemy.detectedstate);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Movement.SetVelocityZero();
        }
    }
}
