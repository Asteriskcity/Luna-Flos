using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    [Serializable]

    public class AttackDamage : AttackData
    {
        [field: SerializeField] public float Amount { get; private set; }
        [field: SerializeField] public float force { get; private set; }
        [field: SerializeField] public Vector2 angle { get; private set; }

    }
}
