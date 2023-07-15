using System;
using Custom.Physics;
using Unity.VisualScripting;
using UnityEngine;
using Custom.UpdateManager;

public class Ball : UpdateBehavior, IGameplayUpdate
{
    [SerializeField] private float speed = 10;

    private int _speedMultiplier = 1;
    private Vector3[] _directions;
    private Vector3 _currDirection;
    
    private ICollider _collider;
    private IBody _body;
    private bool _hasCollider;

    private void Awake()
    {
        _collider = GetComponent<ICollider>();
        _body = GetComponent<IBody>();

        _hasCollider = _collider != null;
    }

    private void Start()
    {
        
        if(_hasCollider)
            _collider.OnCollision += OnCollisionHandler;


        _directions = new[]
        {
            Vector3.forward,
            -Vector3.forward,
            Vector3.forward + Vector3.right,
            Vector3.forward + -Vector3.right,
            -Vector3.forward + Vector3.right,
            -Vector3.forward + -Vector3.right
        };
        
        SetDirection(0);
    }

    public void Tick()
    {
        _body.SetVelocity(_currDirection * (speed * _speedMultiplier));
    }

    public void SetDirection(int index)
    {
        _currDirection = _directions[index];
    }

    private void OnCollisionHandler(ICollider other)
    {
        Debug.Log("Here");
        _speedMultiplier *= -1;
    }
}