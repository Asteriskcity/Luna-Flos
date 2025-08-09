using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    [Serializable]

    public class AttackActionHitbox : AttackData
    {
        public bool debug;

        [field: SerializeField] public Rect HitBox { get; private set; }
    }
}
