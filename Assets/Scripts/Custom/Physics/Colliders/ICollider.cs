using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Custom.Physics
{
    public interface ICollider
    {
        public Vector3 Position { get; }
        public string Tag { get; }
        public int Layer { get; }

        public event UnityAction<ICollider> OnCollision;

        public abstract bool CheckCollision(ICollider other);
        public void InvokeCollision(ICollider other);
        public bool CompareTag(string tag);
        public bool CompareLayer(int layer);
    }
}