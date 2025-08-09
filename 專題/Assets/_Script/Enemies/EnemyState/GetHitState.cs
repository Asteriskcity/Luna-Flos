using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class GetHitState : EnemyState
    {
        public GetHitState(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName) : base(entity, stateMachine, enemiesData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void Exit()
        {
            base.Exit();

            Movement.CanSetVelocity = true;
        }

        public override void ActionTrigger()
        {
            base.ActionTrigger();

            entity.HitVFX.Play();  //TODO:特效應該要放在血量發生變化時
        }
    }
}
