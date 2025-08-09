using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class DamageData : ComponentData<AttackDamage>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Damage);
        }
    }
}
