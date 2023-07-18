using System;
using Custom.Physics;
using Custom.UpdateManager;
using UnityEngine;

public class Block : UpdateBehavior
{
    private ICollider _collider;

    private void Awake()
    {
        _collider = GetComponent<ICollider>();
        if (_collider != null)
        {
            _collider.OnCollision += OnCollisionHandler;
        }
    }

    private void OnCollisionHandler(ICollider other)
    {
        if (other.Layer == LayerMask.NameToLayer("Ball"))
        {
            if (other.Owner.TryGetComponent(out Ball ball))
            {
                ball.SetDirection(3);
            }
            else
            {
                Debug.Log("Here");
            }
        }
    }
}