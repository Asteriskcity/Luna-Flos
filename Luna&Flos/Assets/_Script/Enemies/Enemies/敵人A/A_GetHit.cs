using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class A_GetHit : GetHitState
    {
        private EnemyA enemy;

        public A_GetHit(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyA enemy) : base(entity, stateMachine, enemiesData, animBoolName)
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
    }
}
