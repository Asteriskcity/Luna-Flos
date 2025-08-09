using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.Utils
{
    public class ParallaxEffect : MonoBehaviour
    {

        [SerializeField] Vector2 ParallaxMultipier;

        private Transform CameraTrasform;
        private Vector3 LastCameraPosition;

        private void Start()
        {
            CameraTrasform = Camera.main.transform;
        }

        private void FixedUpdate()
        {
            Vector3 deltaMove = UtilsClass.GetVectorDistance(CameraTrasform.position, LastCameraPosition);
            transform.position += new Vector3(deltaMove.x * ParallaxMultipier.x, deltaMove.y * ParallaxMultipier.y, 0);
            LastCameraPosition = CameraTrasform.position;
        }



    }
}
