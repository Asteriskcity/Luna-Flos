using UnityEngine;


namespace Guagua.Enemies
{
    public class B_Shoot : ShootState
    {
        private EnemyB enemy;

        public B_Shoot(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyB enemy) : base(entity, stateMachine, enemiesData, animBoolName)
        {
            this.enemy = enemy;
        }


        public override void FireAction()
        {
            base.FireAction();

            float angle = Mathf.Atan2(entity.playerDirection.y, entity.playerDirection.x) * Mathf.Rad2Deg;

            GameObject newbullet = Object.Instantiate(enemiesData.Bullet, entity.transform.position, Quaternion.Euler(Vector3.forward * angle));

            newbullet.GetComponent<Rigidbody2D>().velocity =
                new Vector2(enemiesData.BulletSpeed * entity.playerDirection.x, enemiesData.BulletSpeed * entity.playerDirection.y);
        }

        public override void AnimationFinTrigger()
        {
            base.AnimationFinTrigger();

            Movement.CheckWhenToFlip(entity.CheckPlayerDirection());

            if (!isPlayerInAttackRange)
            {
                stateMachine.ChangeState(enemy.detectedstate);
            }
        }
    }
}
