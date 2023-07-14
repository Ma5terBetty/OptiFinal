using System;

namespace CustomPhysics
{
    public struct ColliderUtility
    {
        public static bool IsBoxColliding(BoxCollider self, BoxCollider other)
        {
            if (self.SelfTransform == null || other.SelfTransform == null) return false;
            var selfPos = self.SelfTransform.position;
            var otherPos = other.SelfTransform.position;

            float distanceX = Math.Abs(selfPos.x - otherPos.x);
            float distanceY = Math.Abs(selfPos.y - otherPos.y);
            float distanceZ = Math.Abs(selfPos.z - otherPos.z);

            float sumHalfX = self.SizeOffset.x + other.SizeOffset.x;
            float sumHalfY = self.SizeOffset.y + other.SizeOffset.y;
            float sumHalfZ = self.SizeOffset.z + other.SizeOffset.z;

            return distanceX <= sumHalfX 
                   && distanceY <= sumHalfY
                   &&distanceZ <= sumHalfZ;
        }
    }
}