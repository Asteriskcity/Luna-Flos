using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Utils
{
    [Serializable]
    public class CalculateStats
    {
        [field: SerializeField] public float MaxValue { get; private set; }

        public event Action OnCurrentValueZero;

        public float CurrentValue
        {
            get => currentvalue;
            private set
            {
                currentvalue = Mathf.Clamp(value, 0f, MaxValue);

                if (currentvalue <= 0f)
                {
                    OnCurrentValueZero?.Invoke();
                }
            }
        }

        private float currentvalue;

        public void Init() => CurrentValue = MaxValue;

        public void InCrease(float amount) => CurrentValue += amount;

        public void Decrease(float amount) => CurrentValue -= amount;

    }

}

