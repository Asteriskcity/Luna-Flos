using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Guagua.Utils
{
    public class Timer
    {
        public event Action OnTimerDone;

        private float startTime;
        private float duration;
        private float targetTime;

        private bool isActive;

        public Timer(float duration)
        {
            this.duration = duration;
        }

        public void StartTimer()
        {
            startTime = Time.time;
            targetTime = startTime + duration;
            isActive = true;
        }

        public void Tick()
        {
            if (!isActive)
                return;

            if (Time.time >= targetTime)
            {
                OnTimerDone?.Invoke();
                StopTimer();
            }
        }

        public void StopTimer()
        {
            isActive = false;
        }
    }

}
