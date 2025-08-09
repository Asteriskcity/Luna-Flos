using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    [Serializable]

    public class AttackFireShot : AttackData
    {
        public bool debug;

        [field: SerializeField] public GameObject Bullet;
        //[field: SerializeField] public Transform BulletPosition;

        [field: SerializeField] public float Speed;

        [field: SerializeField] public Vector2 Offset { get; private set; }
        [field: SerializeField][field: Range(0f, 1f)] public float Radius { get; private set; }
    }
}
