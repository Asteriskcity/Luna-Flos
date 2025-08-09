using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public class AttackData
    {
        [SerializeField, HideInInspector] private string name;

        public void SetAttackName(int i) => name = $"Attack {i}";
    }
}
