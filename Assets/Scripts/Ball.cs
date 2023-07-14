using System;
using Custom.Physics;
using Unity.VisualScripting;
using UnityEngine;
using Custom.UpdateManager;

public class Ball : GameplayElement
{
    [SerializeField] private float speed = 10;
    private ICollider _collider;
    private IBody _body;
    private bool _hasCollider;

    private void Awake()
    {
        _collider = GetComponent<ICollider>();
        _body = GetComponent<IBody>();

        _hasCollider = _collider != null;
    }

    protected override void Start()
    {
        base.Start();

        if(_hasCollider)
            _collider.OnCollision += OnCollisionHandler;
    }

    public override void Tick()
    {
        _body.SetVelocity(speed * Vector3.forward);
    }

    private void OnCollisionHandler(ICollider other)
    {
        if(other.CompareLayer(LayerMask.NameToLayer("Block")) 
           || other.CompareLayer(LayerMask.NameToLayer("Player")))
        {
                
            Debug.Log("Collision");
            speed *= 0;
        }
    }
}