using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{

    public class FireShotData : ComponentData<AttackFireShot>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(FireShot);
        }
    }
}
