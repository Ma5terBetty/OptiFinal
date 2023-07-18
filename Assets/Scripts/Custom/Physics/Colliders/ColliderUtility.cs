using System;

namespace Custom.Physics
{
    public struct ColliderUtility
    {
        public static bool IsBoxColliding(CBoxCollider self, CBoxCollider other)
        {
            bool result;
            
            if ((self.transform.position.x + self.SizeOffset.x) > (other.transform.position.x - other.SizeOffset.x)
                && (self.transform.position.x - self.SizeOffset.x) < (other.transform.position.x + other.SizeOffset.x)
                && (self.transform.position.z + self.SizeOffset.z) > (other.transform.position.z - other.SizeOffset.z)
                && (self.transform.position.z - self.SizeOffset.z) < (other.transform.position.z + other.SizeOffset.z))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            
            return result;
            
            /*if (self.transform == null || other.transform == null) return false;
            var selfPos = self.Position;
            var otherPos = other.Position;

            float distanceX = Math.Abs(selfPos.x - otherPos.x);
            float distanceY = Math.Abs(selfPos.y - otherPos.y);
            //float distanceZ = Math.Abs(selfPos.z - otherPos.z);

            float sumHalfX = self.SizeOffset.x + other.SizeOffset.x;
            float sumHalfY = self.SizeOffset.y + other.SizeOffset.y;
            //float sumHalfZ = self.SizeOffset.z + other.SizeOffset.z;

            /*return distanceX <= sumHalfX 
                   && distanceY <= sumHalfY
                   &&distanceZ <= sumHalfZ;

            return distanceX <= sumHalfX && distanceY <= sumHalfY;*/
        }
    }
}

//Nico, yo te quiero mucho, pero por el amor de Dios todopoderoso, comentá tu código.