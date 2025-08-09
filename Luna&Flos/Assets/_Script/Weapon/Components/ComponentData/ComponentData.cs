using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.WeaponSystem
{
    [Serializable]

    public abstract class ComponentData
    {
        [SerializeField, HideInInspector] private string name;

        public Type ComponentDependency { get; protected set; }

        public ComponentData() //一被呼叫就會執行下面這個函數
        {
            SetComponentName();
            SetComponentDependency();
        }

        public void SetComponentName() => name = GetType().Name;

        protected abstract void SetComponentDependency();

        public virtual void SetAttackDataName() { }

        public virtual void InitializeAttackData(int numberofAttacks) { }
    }



    [Serializable]

    public abstract class ComponentData<T> : ComponentData where T : AttackData
    {
        [SerializeField] private T[] attackData;

        public T[] AttackData { get => attackData; private set => attackData = value; }

        public override void SetAttackDataName()
        {
            base.SetAttackDataName();

            for (var i = 0; i < AttackData.Length; i++)
            {
                AttackData[i].SetAttackName(i + 1);
            }
        }

        public override void InitializeAttackData(int numberofAttacks)
        {
            base.InitializeAttackData(numberofAttacks);

            var oldlengh = attackData != null ? attackData.Length : 0;

            if (oldlengh == numberofAttacks)
                return;

            Array.Resize(ref attackData, numberofAttacks);

            if (oldlengh < numberofAttacks)
            {
                for (var i = oldlengh; i < attackData.Length; i++)
                {
                    var newobj = Activator.CreateInstance(typeof(T)) as T;
                    attackData[i] = newobj;
                }
            }

            SetAttackDataName();
        }


    }

}
