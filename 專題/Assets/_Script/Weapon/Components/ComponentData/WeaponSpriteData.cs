using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{

    public class WeaponSpriteData : ComponentData<AttackSprite>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(WeaponSprite);
        }
    }
}

