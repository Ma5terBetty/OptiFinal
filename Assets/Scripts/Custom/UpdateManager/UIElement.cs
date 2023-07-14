using UnityEngine;

namespace Custom.UpdateManager
{
    public abstract class UIElement : MonoBehaviour
    {
        protected virtual void Start()
        {
            CustomUpdateManager.Instance.AddUIElement(this);
        }

        public abstract void Tick();
    }
}