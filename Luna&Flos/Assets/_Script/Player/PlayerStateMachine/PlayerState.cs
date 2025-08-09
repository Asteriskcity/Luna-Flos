using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guagua.CoreSystem;

namespace Guagua.Nia
{
    public class PlayerState
    {
        protected Core core;

        protected Player player;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;


        protected bool isAnimationFinished;
        protected bool isExitingState;

        public float StarTime { get; private set; }

        private readonly string animBoolName;


        #region Core Component

        protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
        private Movement movement;

        protected CollisionSense CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSense>(); }
        private CollisionSense collisionSenses;

        protected Form Form { get => form ??= core.GetCoreComponent<Form>(); }
        private Form form;

        protected Stats Stats { get => stats ??= core.GetCoreComponent<Stats>(); }
        private Stats stats;

        protected SwitchManager SwitchManager { get => switchManager ??= core.GetCoreComponent<SwitchManager>(); }
        private SwitchManager switchManager;

        protected ParticleManager ParticleManager { get => particleManager ??= core.GetCoreComponent<ParticleManager>(); }
        private ParticleManager particleManager;

        #endregion


        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animBoolName = animBoolName;
            core = player.core;
        }

        public virtual void Enter()
        {
            DoChecks();
            player.Anim.SetBool(animBoolName, true);
            StarTime = Time.time;

            isAnimationFinished = false;
            isExitingState = false;

            //Debug.Log(animBoolName);

        }

        public virtual void Exit()
        {
            player.Anim.SetBool(animBoolName, false);
            isExitingState = true;
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

        public virtual void AnimationTrigger() { }

        public virtual void AnimationFinTrigger() => isAnimationFinished = true;

    }
}

