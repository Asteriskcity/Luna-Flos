using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Guagua.Enemies
{
    public class DetectPlayerState : EnemyState
    {

        protected bool isDetectedplayer;
        protected bool isDetectedWall;
        protected bool isDetectedLedge;
        protected bool isPlayerInAttackRange;

        public DetectPlayerState(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName) : base(entity, stateMachine, enemiesData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            Movement.CheckWhenToFlip(entity.CheckPlayerDirection());

            isDetectedWall = EnemyCollision.WallFront;
            isDetectedLedge = EnemyCollision.LedgeVertical;
            isDetectedplayer = EnemyCollision.PlayerDetected();
            isPlayerInAttackRange = EnemyCollision.PlayerInAttackRange;
        }
    }

    public enum EnemiesAction
    {
        ChasingPlayer,
        BackToPosition
    }
}
