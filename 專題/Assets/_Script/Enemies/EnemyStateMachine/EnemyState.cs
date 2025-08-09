using System.Collections;
using System.Collections.Generic;
using Guagua.CoreSystem;
using UnityEngine;

namespace Guagua.Enemies
{
    public class EnemyState
    {
        protected Core core;

        protected EnemyStateMachine stateMachine;
        protected Entity entity;

        protected EnemiesData enemiesData;

        protected string animBoolName;

        public float startTime { get; protected set; }


        #region CoreComponents

        protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
        private Movement movement;

        protected EnemyCollision EnemyCollision { get => enemycollision ??= core.GetCoreComponent<EnemyCollision>(); }
        private EnemyCollision enemycollision;

        #endregion


        public EnemyState(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName)
        {
            this.entity = entity;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
            this.enemiesData = enemiesData;
            core = entity.Core;
        }

        public virtual void Enter()
        {
            startTime = Time.time;
            entity.anim.SetBool(animBoolName, true);
            DoChecks();
        }

        public virtual void Exit()
        {
            entity.anim.SetBool(animBoolName, false);
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }

        public virtual void AnimationFinTrigger() { }
        public virtual void ActionTrigger() { }
    }
}
