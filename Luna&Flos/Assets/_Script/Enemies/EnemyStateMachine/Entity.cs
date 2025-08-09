using System;
using UnityEngine;
using Guagua.Nia;
using Guagua.CoreSystem;
using Guagua.Utils;


namespace Guagua.Enemies
{
    public class Entity : MonoBehaviour
    {
        public ParticleSystem HitVFX;

        public EnemyStateMachine stateMachine { get; private set; }
        public EnemiesData enemiesData;

        public Animator anim { get; private set; }

        public Core Core;

        public Vector2 playerDirection { get; private set; }
        //public Vector2 RespwnPosition { get; private set; }


        protected Movement movement;
        protected EnemyCollision enemyCollision;
        protected Stats stats;


        public virtual void Awake()
        {
            Core = GetComponentInChildren<Core>();

            anim = GetComponent<Animator>();

            movement = Core.GetCoreComponent<Movement>();
            enemyCollision = Core.GetCoreComponent<EnemyCollision>();
            stats = Core.GetCoreComponent<Stats>();

            stateMachine = new EnemyStateMachine();

            //RespwnPosition = transform.position;
        }

        public virtual void Start() { }


        public virtual void OnDestroy() { }


        public virtual void Update()
        {
            Core.LogicUpdate();
            stateMachine.CurrentState.LogicUpdate();

            CheckPlayerDirection();
        }

        public virtual void FixedUpdate()
        {
            stateMachine.CurrentState.PhysicsUpdate();
        }



        private void AnimationFinTrigger() => stateMachine.CurrentState.AnimationFinTrigger();
        private void ActionTrigger() => stateMachine.CurrentState.ActionTrigger();


        //碰撞傷害
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player") && !Player.inIFrame)
            {
                if (other.collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(enemiesData.CollideDamage);
                }

                if (other.collider.TryGetComponent(out IKnockback knockable))
                {
                    knockable.KnockBack(movement.FacingDirection, enemiesData.Force, enemiesData.Angle);
                }
            }
        }


        public int CheckPlayerDirection()
        {
            playerDirection = UtilsClass.GetVectorDistance(enemyCollision.playerPosition, transform.position).normalized;

            return playerDirection.x <= 0 ? -1 : 1;
        }



        public virtual void OnDrawGizmos()
        {
            if (Core != null)
            {
                Gizmos.DrawLine(enemyCollision.Wallcheck.position, enemyCollision.Wallcheck.position +
                        (Vector3)(Vector2.right * movement.FacingDirection * enemyCollision.wallCheckDistance));
                Gizmos.DrawLine(enemyCollision.LedgecheckVertical.position, enemyCollision.LedgecheckVertical.position +
                        (Vector3)(Vector2.down * enemyCollision.wallCheckDistance));
                Gizmos.DrawWireSphere(enemyCollision.Attackposition.position, enemyCollision.attackRadius);
                Gizmos.DrawWireSphere(transform.position + new Vector3(enemyCollision.playerDistance, 0, 0), 0.6f);
                Gizmos.DrawWireSphere(transform.position - new Vector3(enemyCollision.playerDistance, 0, 0), 0.6f);
            }
        }

    }
}
