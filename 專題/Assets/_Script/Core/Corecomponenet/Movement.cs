using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.CoreSystem
{
    public class Movement : CoreComponent
    {
        public Rigidbody2D Rb { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }

        public bool CanSetVelocity { get; set; }

        public int FacingDirection = 1;

        private Vector2 workspace;

        protected override void Awake()
        {
            base.Awake();

            Rb = GetComponentInParent<Rigidbody2D>();

            CanSetVelocity = true;
        }

        public override void LogicUpdate()
        {
            CurrentVelocity = Rb.velocity;
        }


        #region SetFuctions


        public void SetVelocityZero()
        {
            workspace = Vector2.zero;
            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            workspace.Set(angle.x * velocity * direction, angle.y * velocity);
            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            workspace = direction * velocity;
            SetFinalVelocity();
        }


        public void SetVelocityX(float velocity)
        {
            workspace.Set(velocity, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public void SetVelocityY(float velocity)
        {
            workspace.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }

        private void SetFinalVelocity()
        {
            if (CanSetVelocity)
            {
                Rb.velocity = workspace;
                CurrentVelocity = workspace;
            }
        }

        #endregion


        public void CheckWhenToFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
            {
                Flip();
            }
        }

        public void Flip()
        {
            FacingDirection *= -1;
            Rb.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

}
