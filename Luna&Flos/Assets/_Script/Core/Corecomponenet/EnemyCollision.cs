using System;
using System.Collections;
using System.Collections.Generic;
using Guagua.Nia;
using Unity.VisualScripting;
using UnityEngine;

namespace Guagua.CoreSystem
{
    public class EnemyCollision : CoreComponent
    {

        public Transform Wallcheck { get => wallCheck; private set => wallCheck = value; }

        public Transform LedgecheckVertical { get => ledgecheckVertical; private set => ledgecheckVertical = value; }

        public Transform Playercheck { get => playercheck; private set => playercheck = value; }

        public Transform Attackposition { get => attackposition; private set => attackposition = value; }



        [Header("CheckTransform")]
        [SerializeField] private Transform wallCheck;
        [SerializeField] private Transform ledgecheckVertical;
        [SerializeField] private Transform attackposition;
        private Transform playercheck;


        [Header("Check Variables")]
        [SerializeField] private LayerMask whatIsGround;
        public LayerMask whatIsPlayer;
        public float wallCheckDistance = 0.2f;
        public float attackRadius = 0.4f;
        public float playerDistance = 4f;

        private Movement Movement;

        [HideInInspector]
        public Vector3 playerPosition;


        protected override void Awake()
        {
            base.Awake();

            Movement = core.GetCoreComponent<Movement>();

            playercheck = FindObjectOfType<Player>().transform;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            playerPosition = playercheck.position;
        }



        public bool WallFront
        {
            get => Physics2D.Raycast(Wallcheck.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);
        }

        public bool LedgeVertical
        {
            get => Physics2D.Raycast(LedgecheckVertical.position, Vector2.down, wallCheckDistance, whatIsGround);
        }

        public bool PlayerInAttackRange
        {
            get => Physics2D.OverlapCircle(Attackposition.position, attackRadius, whatIsPlayer);
        }

        public bool PlayerDetected()
        {
            return CheckPlayerDistance() <= playerDistance;
        }

        public float CheckPlayerDistance()
        {
            return Vector3.Distance(playerPosition, transform.position);
        }


    }
}
