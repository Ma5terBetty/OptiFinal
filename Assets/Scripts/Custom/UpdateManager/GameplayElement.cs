using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.UpdateManager
{
    public abstract class GameplayElement : MonoBehaviour
    {
        protected virtual void Start()
        {
            CustomUpdateManager.Instance.AddGameplayElement(this);
        }

        public abstract void Tick();
    }
}
