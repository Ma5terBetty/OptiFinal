using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Collider = CustomPhysics.Collider;

namespace CustomPhysics
{
    public class ColliderManager : MonoBehaviour
    {
        public static ColliderManager Instance { get; private set; }
        [field: SerializeField] public List<Collider> Colliders { get; private set; }

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
            
            Colliders = new List<Collider>();
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
                        curr.OnCollision?.Invoke(other);
                    }
                }
            }
        }
        
        public void Add(Collider input)
        {
            if (Colliders.Contains(input)) return;
            
            Colliders.Add(input);
        }

        public void Remove(Collider input)
        {
            if (!Colliders.Contains(input)) return;
            
            Colliders.Remove(input);
        }

    }
}