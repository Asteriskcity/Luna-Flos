using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class MoveState : EnemyState
    {

        protected bool isMovingTimesup;
        protected bool isDetectedWall;
        protected bool isDetectedLedge;
        protected bool isDetectedplayer;


        public MoveState(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName) : base(entity, stateMachine, enemiesData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isDetectedWall = EnemyCollision.WallFront;
            isDetectedLedge = EnemyCollision.LedgeVertical;
            isDetectedplayer = EnemyCollision.PlayerDetected();
        }

        public override void Enter()
        {
            base.Enter();

            isMovingTimesup = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= startTime + enemiesData.Movetime)
            {
                isMovingTimesup = true;
            }

        }

    }
}
