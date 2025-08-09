using System.Collections;
using System.Collections.Generic;
using Guagua.CoreSystem;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    public abstract class WeaponComponents : MonoBehaviour
    {
        protected Weapon weapon;
        protected PlayerInputHandler inputHandler;
        protected Core Core => weapon.Core;
        protected AnimationEventHandler EventHandler => weapon.EventHandler;

        protected bool isAttackAcitve;

        public virtual void Init()
        {

        }

        protected virtual void Awake()
        {
            weapon = GetComponent<Weapon>();
            inputHandler = GetComponentInParent<PlayerInputHandler>();
        }

        protected virtual void Start()
        {
            weapon.OnEnter += HandleEnter;
            weapon.OnExit += HandleExit;
        }

        protected virtual void HandleEnter()
        {
            isAttackAcitve = true;
        }

        protected virtual void HandleExit()
        {
            isAttackAcitve = false;
        }

        protected virtual void OnDestroy()
        {
            weapon.OnEnter -= HandleEnter;
            weapon.OnExit -= HandleExit;
        }
    }

    public abstract class WeaponComponent<T1, T2> : WeaponComponents where T1 : ComponentData<T2> where T2 : AttackData
    {
        protected T1 data;
        protected T2 currentAttackData;

        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentAttackData = data.AttackData[weapon.CurrentAttackCounter];
        }

        public override void Init()
        {
            base.Init();

            data = weapon.DataSO.GetData<T1>();
        }
    }
}

