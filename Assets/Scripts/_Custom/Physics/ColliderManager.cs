using System;
using System.Collections.Generic;
using UnityEngine;
using Custom.UpdateManager;

namespace Custom.Physics
{
    public class ColliderManager : UpdateBehavior, IPhysicsUpdate
    {
        //Just for debug
        [SerializeField] private int colliderCount;
        public static ColliderManager Instance { get; private set; }
        public List<ICollider> Colliders { get; private set; }

        private void Awake()
        {
            if (ColliderManager.Instance == null)
            {
                ColliderManager.Instance = this;
            }
            else
            {
                Destroy(this);
            }
            
            Colliders = new List<ICollider>();
        }

        public void Tick()
        {
            CheckColliders();
        }

        public void CheckColliders()
        {
            var count = Colliders.Count;

            for (int i = 0; i < count; i++)
            {
                var curr = Colliders[i];
                
                for (int j = 0; j < count; j++)
                {
                    if(i == j) continue;

                    var other = Colliders[j];
                    if (curr.CheckCollision(other))
                    {
                        curr.InvokeCollision(other);
                    }
                }
            }
        }
        
        public void Add(ICollider input)
        {
            if (Colliders.Contains(input)) return;
            
            Colliders.Add(input);
            colliderCount++;
        }

        public void Remove(ICollider input)
        {
            if (!Colliders.Contains(input)) return;
            
            Colliders.Remove(input);
            colliderCount--;
        }


    }
}