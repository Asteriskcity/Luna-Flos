using System.Collections;
using UnityEngine;
using Guagua.CoreSystem;
using Guagua.WeaponSystem;


namespace Guagua.Nia
{
    public class Player : MonoBehaviour
    {
        #region State Variables 

        public PlayerStateMachine StateMachine { get; private set; }

        public State_Idle IdleState { get; private set; }
        public State_Move MoveState { get; private set; }
        public State_Dash DashState { get; private set; }
        public State_Jump JumpState { get; private set; }
        public State_InAir InAirState { get; private set; }
        public State_OnLand OnLandState { get; private set; }
        public State_Attack AttackState { get; private set; }
        public State_GetHit GetHitState { get; private set; }
        public State_SwitchForm SwitchFormState { get; private set; }

        #endregion

        #region Components

        public Core core { get; private set; }

        public Animator Anim { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }

        public static Transform playerposition;

        public static bool inIFrame;

        [SerializeField] private PlayerData playerData;
        [SerializeField] private Weapon weapon;
        [SerializeField] private WeaponGenerator weaponGenerator;

        private Stats stats;
        private SwitchManager switchManager;
        private CollisionSense collisionSense;

        #endregion

        #region CallBack Fuctions

        private void Awake()
        {
            core = GetComponentInChildren<Core>();

            weapon.SetCore(core);

            StateMachine = new PlayerStateMachine();

            IdleState = new State_Idle(this, StateMachine, playerData, "idle");
            MoveState = new State_Move(this, StateMachine, playerData, "move");
            DashState = new State_Dash(this, StateMachine, playerData, "dash");
            JumpState = new State_Jump(this, StateMachine, playerData, "inAir");
            InAirState = new State_InAir(this, StateMachine, playerData, "inAir");
            OnLandState = new State_OnLand(this, StateMachine, playerData, "onLand");
            GetHitState = new State_GetHit(this, StateMachine, playerData, "getHit");
            AttackState = new State_Attack(this, StateMachine, playerData, "attack", weapon);
            SwitchFormState = new State_SwitchForm(this, StateMachine, playerData, "switchform", weaponGenerator);

            stats = core.GetCoreComponent<Stats>();
            switchManager = core.GetCoreComponent<SwitchManager>();
            collisionSense = core.GetCoreComponent<CollisionSense>();

            playerposition = gameObject.transform;
            DontDestroyOnLoad(gameObject.transform.root.gameObject);
        }

        private void Start()
        {
            Anim = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();

            stats.OnGetHit += HandleGetHit;
            switchManager.OnSwitchInput += HandelSwitchInput;

            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            core.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        private void OnDestroy()
        {
            stats.OnGetHit -= HandleGetHit;
            switchManager.OnSwitchInput -= HandelSwitchInput;
        }

        #endregion

        private IEnumerator InvincibilityFrame()
        {
            inIFrame = true;
            //Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("敵人"), false);
            yield return new WaitForSeconds(playerData.IFrameTime);
            inIFrame = false;
            //Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("敵人"), true);
        }

        private void HandleGetHit()
        {
            StateMachine.ChangeState(GetHitState);
            StartCoroutine(InvincibilityFrame());
        }

        private void HandelSwitchInput()
        {
            StateMachine.ChangeState(SwitchFormState);
        }

        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

        private void AnimationFinTrigger() => StateMachine.CurrentState.AnimationFinTrigger();


    }

}


