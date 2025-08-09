using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class DeadState : EnemyState
    {

        public DeadState(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName) : base(entity, stateMachine, enemiesData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Movement.SetVelocityZero();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void AnimationFinTrigger()
        {
            base.AnimationFinTrigger();

            core.transform.root.gameObject.SetActive(false);
        }
    }
}
