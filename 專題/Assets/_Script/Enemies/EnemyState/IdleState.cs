using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class IdleState : EnemyState
    {
        protected bool isIdletTimessUp;
        protected bool isDetectedplayer;
        protected bool isPlayerInAttackRange;

        protected float idleTime;

        public IdleState(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName) : base(entity, stateMachine, enemiesData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isDetectedplayer = EnemyCollision.PlayerDetected();
            isPlayerInAttackRange = EnemyCollision.PlayerInAttackRange;
        }

        public override void Enter()
        {
            base.Enter();

            isIdletTimessUp = false;

            SetRandomIdleTime();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement.SetVelocityZero();

            if (Time.time >= startTime + idleTime)
            {
                isIdletTimessUp = true;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void SetRandomIdleTime()
        {
            idleTime = Random.Range(enemiesData.minIdletime, enemiesData.maxIdletime);
        }


    }
}
