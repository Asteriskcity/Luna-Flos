using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.CoreSystem
{
    public class KnockbackReciever : CoreComponent, IKnockback
    {

        private Movement movement;
        private Stats stats;

        protected override void Awake()
        {
            base.Awake();

            movement = core.GetCoreComponent<Movement>();
            stats = core.GetCoreComponent<Stats>();
        }


        public void KnockBack(int direction, float force, Vector2 angle)
        {
            if (stats.HealthPoint.CurrentValue == 0)
                return;

            movement.CheckWhenToFlip(-direction);
            movement.SetVelocity(force, angle, direction);
            movement.CanSetVelocity = false;
        }


    }
}
