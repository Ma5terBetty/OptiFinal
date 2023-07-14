using System;
using UnityEngine;

namespace CustomPhysics
{
    [Serializable]
    public class BoxCollider : Collider
    {
        public Vector3 size;
        public Vector3 SizeOffset => size / 2;

        public BoxCollider(Transform selfTransform,string tag,int layer , Action<Collider> onCollisionHandler) : base(selfTransform,tag,layer, onCollisionHandler)
        {
            size = selfTransform.localScale;
        }

        public override bool CheckCollision(Collider other)
        {
            return ColliderUtility.IsBoxColliding(this, (BoxCollider)other);
        }
    }
}