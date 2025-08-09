using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.CoreSystem
{
    public class CollisionSense : CoreComponent
    {

        public Transform Groundcheck { get => groundcheck; private set => groundcheck = value; }




        [Header("CheckTransform")]
        [SerializeField] private Transform groundcheck;

        [Header("Check Variables")]
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] float groundcheckRadius = 0.3f;


        /*private Movement Movement;

        protected override void Awake()
        {
            base.Awake();

            Movement = core.GetCoreComponent<Movement>();
        }*/

        public bool Ground()
        {
            Collider2D ground = Physics2D.OverlapCircle(Groundcheck.position, groundcheckRadius, whatIsGround);

            return ground != null;
        }






    }
}

