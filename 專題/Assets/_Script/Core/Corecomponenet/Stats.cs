using System;
using UnityEngine;
using Guagua.Utils;

namespace Guagua.CoreSystem
{
    public class Stats : CoreComponent
    {

        [field: SerializeField] public CalculateStats HealthPoint { get; private set; }


        public event Action OnValueChange;
        public event Action OnGetHit;
        public event Action OnDeath;


        protected override void Awake()
        {
            base.Awake();

            HealthPoint.Init();

            HealthPoint.OnCurrentValueZero += Death;
        }




        #region HP 

        public void TakeDamage(float amount)
        {
            HealthPoint.Decrease(amount);

            OnValueChange?.Invoke();

            if (HealthPoint.CurrentValue != 0)
                OnGetHit?.Invoke();
        }

        public void GetHeal(float amount)
        {
            HealthPoint.InCrease(amount);
        }

        private void Death()
        {
            Debug.Log("I'm dead!");
            OnDeath?.Invoke();
        }

        #endregion
    }
}
