using System;
using CustomPhysics;
using UnityEngine;
using Collider = CustomPhysics.Collider;

public class Block : MonoBehaviour
{
    private Collider _collider;
    private PhysicsBody _body;

    private void Start()
    {
        var selfTransform = transform;
        _collider = new CustomPhysics.BoxCollider(selfTransform,gameObject.tag,gameObject.layer, OnCollisionHandler);
        _body = new PhysicsBody(selfTransform);
    }

    private void OnCollisionHandler(Collider other)
    {
        
    }
}