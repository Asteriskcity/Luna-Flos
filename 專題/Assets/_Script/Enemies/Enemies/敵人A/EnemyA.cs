using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Enemies
{
    public class EnemyA : Entity
    {

        public A_Idle idlestate { get; private set; }
        public A_Move movestate { get; private set; }
        public A_DetectedPlayer detectedstate { get; private set; }
        public A_Attack attackstate { get; private set; }
        public A_GetHit getHitstate { get; private set; }

        public DeadState deadstate { get; private set; }


        public override void Awake()
        {
            base.Awake();

            getHitstate = new A_GetHit(this, stateMachine, enemiesData, "getHit", this);
            idlestate = new A_Idle(this, stateMachine, enemiesData, "idle", this);
            movestate = new A_Move(this, stateMachine, enemiesData, "move", this);
            attackstate = new A_Attack(this, stateMachine, enemiesData, "attack", this);
            detectedstate = new A_DetectedPlayer(this, stateMachine, enemiesData, "move", this);

            deadstate = new DeadState(this, stateMachine, enemiesData, "dead");
        }

        public override void Start()
        {
            base.Start();

            stateMachine.Initialize(idlestate);

            stats.OnDeath += HandleDeath;
            stats.OnGetHit += HandleGetHit;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            stats.OnGetHit -= HandleGetHit;
            stats.OnDeath -= HandleDeath;
        }

        private void HandleDeath()
        {
            Debug.Log(5566);
            stateMachine.ChangeState(deadstate);
        }


        private void HandleGetHit()
        {
            stateMachine.ChangeState(getHitstate);
        }


    }
}
