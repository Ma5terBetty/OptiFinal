using System;
using UnityEngine;
using Custom.UpdateManager;

namespace Custom.Physics
{
    public class PhysicsBody : PhysicsElement, IBody
    {
        public Vector3 Velocity { get; private set; }

        public override void Tick()
        {
            transform.position += Velocity * Time.deltaTime;
        }

        public void AddVelocity(Vector3 input)
        {
            Velocity += input;
        }

        public void SetVelocity(Vector3 input)
        {
            Velocity = input;
        }

        public void Freeze()
        {
            Velocity = Vector3.zero;
        }
    }
}