
namespace Guagua.Enemies
{
    public class B_DetectedPlayer : DetectPlayerState
    {

        private EnemyB enemy;

        public B_DetectedPlayer(Entity entity, EnemyStateMachine stateMachine, EnemiesData enemiesData, string animBoolName, EnemyB enemy) : base(entity, stateMachine, enemiesData, animBoolName)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInAttackRange)
            {
                stateMachine.ChangeState(enemy.shootstate);
            }
            else if (EnemyCollision.CheckPlayerDistance() >= enemiesData.MaxTracingRange)
            {
                stateMachine.ChangeState(enemy.idlestate);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Movement.SetVelocity(enemiesData.movespeed, entity.playerDirection);
        }
    }


}
