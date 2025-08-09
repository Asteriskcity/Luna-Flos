using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class B_Idle : IdleState
    {

        private EnemyB enemy;

        public B_Idle(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyB enemy) : base(entity, stateMachine, enemiesData, animBoolName)
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
            else if (isIdletTimessUp)
            {
                stateMachine.ChangeState(enemy.movestate);
            }
        }

        public override void Exit()
        {
            base.Exit();

            Movement.Flip();
        }
    }
}

