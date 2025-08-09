using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guagua.CoreSystem
{
    public class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core core;

        protected virtual void Awake()
        {
            core = transform.parent.GetComponent<Core>();

            if (core == null) { Debug.LogError("No core :("); }
            core.AddComponent(this);
        }

        public virtual void LogicUpdate() { }
    }
}

