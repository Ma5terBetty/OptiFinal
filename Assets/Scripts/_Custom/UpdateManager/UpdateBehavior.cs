using System;
using UnityEngine;

namespace Custom.UpdateManager
{
    public abstract class UpdateBehavior: MonoBehaviour, IUpdatable
    {
        protected virtual void OnEnable()
        {
            this.RegisterInManager();
        }

        protected virtual void OnDisable()
        {
            this.UnregisterInManager();    
        }
    }
}