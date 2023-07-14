using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Custom.Physics
{
    public class BoxCollider : Collider
    {
        public Vector3 Size => transform.localScale;
        public Vector3 SizeOffset => Size / 2;

        public override bool CheckCollision(ICollider other)
        {
            return ColliderUtility.IsBoxColliding(this, (BoxCollider)other);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, Size);
        }
    }
}