using System;

namespace Custom.Physics
{
    public struct ColliderUtility
    {
        public static bool IsBoxColliding(CBoxCollider self, CBoxCollider other)
        {
            if (self.transform == null || other.transform == null) return false;
            var selfPos = self.Position;
            var otherPos = other.Position;

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