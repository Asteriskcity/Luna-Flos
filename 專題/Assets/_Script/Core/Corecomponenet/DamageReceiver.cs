using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Guagua.CoreSystem
{
    public class DamageReceiver : CoreComponent, IDamageable
    {
        private Stats stats;

        public void Damage(float amount)
        {
            stats.TakeDamage(amount);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
        }
    }
}
