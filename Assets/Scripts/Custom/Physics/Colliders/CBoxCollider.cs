using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Custom.Physics
{
    public class CBoxCollider : Collider
    {
        [SerializeField] private Vector3 sizeOffset = Vector3.one;
        public Vector3 Size => transform.localScale + (sizeOffset - Vector3.one);
        public Vector3 SizeOffset => Size / 2;

        public override bool CheckCollision(ICollider other)
        {
            return ColliderUtility.IsBoxColliding(this, (CBoxCollider)other);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, Size);
        }
    }
}