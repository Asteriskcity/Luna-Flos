using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class A_Idle : IdleState
    {
        private EnemyA enemy;

        public A_Idle(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyA enemy) : base(entity, stateMachine, enemiesData, animBoolName)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
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
        }


    }
}
