using System;
using Custom.Physics;
using UnityEngine;
using UnityEngine.Events;

namespace Custom.Physics
{
    [Serializable]
    public abstract class Collider : MonoBehaviour, ICollider
    {
        public Vector3 Position => transform.position;
        public string Tag { get; private set; }
        public int Layer { get; private set; }
        public event UnityAction<ICollider> OnCollision;

        private void Start()
        {
            ColliderManager.Instance.Add(this);
        }

        public abstract bool CheckCollision(ICollider other);
        public void InvokeCollision(ICollider other)
        {
            OnCollision?.Invoke(other);
        }
        
        public bool CompareTag(string tag)
        {
            return Tag == tag;
        }
        
        public bool CompareLayer(int layer)
        {
            return Layer == layer;
        }
    }
}