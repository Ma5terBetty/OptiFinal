using UnityEngine;

namespace Custom.UpdateManager
{
    public abstract class PhysicsElement : MonoBehaviour
    {
        protected virtual void Start()
        {
            CustomUpdateManager.Instance.AddPhysicsElement(this);
        }

        public abstract void Tick();
    }
}