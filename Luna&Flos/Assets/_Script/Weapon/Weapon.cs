using System;
using UnityEngine;
using Guagua.CoreSystem;
using Guagua.Utils;

namespace Guagua.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float attackCounterResetCooldown;

        public WeaponDataSO DataSO { get; private set; }

        public Core Core { get; private set; }

        private Timer attackCounterResetTimer;

        public Animator Anim;
        public GameObject BaseGameobject { get; private set; }
        public GameObject WeaponSpriteGameobject { get; private set; }

        private AnimationEventHandler eventHandler;

        public AnimationEventHandler EventHandler
        {
            get
            {
                if (!initDone)
                {
                    GetDependencies();
                }

                return eventHandler;
            }
            private set => eventHandler = value;
        }

        public event Action OnEnter;
        public event Action OnExit;

        private bool initDone;

        private int currentAttackCounter;

        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set => currentAttackCounter = value >= DataSO.NumberOfAttacks ? 0 : value;
        }

        private void Awake()
        {
            GetDependencies();

            attackCounterResetTimer = new Timer(attackCounterResetCooldown);
        }

        private void Update()
        {
            attackCounterResetTimer.Tick();
        }

        private void ResetAttackCounter() => CurrentAttackCounter = 0;

        public void SetCore(Core core)
        {
            Core = core;
        }

        public void SetWeaponData(WeaponDataSO dataSO)
        {
            DataSO = dataSO;

            if (dataSO == null)
                return;

            ResetAttackCounter();
        }

        private void GetDependencies()
        {
            if (initDone)
                return;

            BaseGameobject = transform.Find("Base").gameObject;
            WeaponSpriteGameobject = transform.Find("WeaponSprite").gameObject;

            Anim = BaseGameobject.GetComponent<Animator>();
            EventHandler = BaseGameobject.GetComponent<AnimationEventHandler>();

            initDone = true;
        }

        private void OnEnable()
        {
            EventHandler.OnFinish += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable()
        {
            EventHandler.OnFinish -= Exit;
            attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
        }

        public void Enter()
        {
            attackCounterResetTimer.StopTimer();

            Anim.SetBool("active", true);
            Anim.SetInteger("counter", CurrentAttackCounter);

            OnEnter?.Invoke();
        }

        private void Exit()
        {
            Anim.SetBool("active", false);

            CurrentAttackCounter++;
            attackCounterResetTimer.StartTimer();

            OnExit?.Invoke();
        }

        public void HandleStopAttack()
        {
            Anim.SetBool("active", false);
            ResetAttackCounter();
            OnExit?.Invoke();
        }
    }
}

