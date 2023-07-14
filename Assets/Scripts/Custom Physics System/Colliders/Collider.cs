using System;
using CustomPhysics;
using UnityEngine;
using UnityEngine.Events;

namespace CustomPhysics
{
    [Serializable]
    public abstract class Collider
    {
        public Transform SelfTransform { get; private set; }
        public string Tag { get; private set; }
        public int Layer { get; private set; }

        public Action<Collider> OnCollision;

        public Collider(Transform selfTransform, string tag, int layer, Action<Collider> onCollisionHandler)
        {
            this.SelfTransform = selfTransform;
            this.Tag = tag;
            this.Layer = layer;
            
            ColliderManager.Instance.Add(this);
            OnCollision += onCollisionHandler;
        }

        public abstract bool CheckCollision(Collider other);

        public bool CompareTag(Collider collider)
        {
            return Tag == collider.Tag;
        }

        public bool CompareLayer(Collider collider)
        {
            return Layer == collider.Layer;
        }
    }
}