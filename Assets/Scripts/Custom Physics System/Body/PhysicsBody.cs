using System;
using UnityEngine;

namespace CustomPhysics
{
    [Serializable]
    public class PhysicsBody
    {
        private Transform _transform;
        public Vector3 velocity { get; set; }

        public PhysicsBody(Transform transform)
        {
            _transform = transform;
            CustomUpdateManager.Instance.AddPhysicsBody(this);
        }

        public void Tick()
        {
            _transform.position += velocity * Time.deltaTime;
        }

        public void AddVelocity(Vector3 input)
        {
            velocity += input;
        }

        public void SetVelocity(Vector3 input)
        {
            velocity = input;
        }

        public void Freeze()
        {
            velocity = Vector3.zero;
        }
    }
}