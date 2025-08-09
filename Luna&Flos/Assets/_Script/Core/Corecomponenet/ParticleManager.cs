using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.CoreSystem
{
    public class ParticleManager : CoreComponent
    {

        public Transform LandDust;
        public Transform MoveDust;

        protected override void Awake()
        {
            base.Awake();
        }

        public GameObject StartParticles(GameObject particlePrefab, Vector2 position, Quaternion rotation)
        {
            return Instantiate(particlePrefab, position, rotation);
        }

    }
}
