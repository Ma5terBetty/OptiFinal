using UnityEngine;

namespace Custom.Physics
{
    public interface IBody
    {
        public Vector3 Velocity { get; }
        public void AddVelocity(Vector3 input);
        public void SetVelocity(Vector3 input);
        public void Freeze();
    }
}