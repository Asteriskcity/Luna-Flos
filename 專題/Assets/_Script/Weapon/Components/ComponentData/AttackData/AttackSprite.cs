using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    [Serializable]

    public class AttackSprite : AttackData
    {
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
    }
}

