using System;
using _Custom.Pool;
using Custom.Physics;
using Unity.VisualScripting;
using UnityEngine;
using Custom.UpdateManager;
using UnityEngine.Events;

public class Ball : UpdateBehavior, IGameplayUpdate, ICustomPoolable<Ball>
{
    [SerializeField] private float speed = 10;

    private int _speedMultiplier = 1;
    private Vector3[] _directions;
    private Vector3 _currDirection;
    
    private ICollider _collider;
    private IBody _body;

    private bool _isFroze;
    private bool _hasCollider;
    public event Action<Ball> OnRecycle;

    private void Awake()
    {
        _collider = GetComponent<ICollider>();
        _body = GetComponent<IBody>();

        if (_collider != null)
        {
            _collider.OnCollision += OnCollisionHandler;
        }

        OnRecycle += OnRecycleHandler;
        
        _directions = new[]
        {
            Vector3.forward,                  // Forward 0
            Vector3.forward + Vector3.right,  // Right Diagonal Forward 1
            Vector3.forward - Vector3.right, // Left Diagonal Forward 2
            -Vector3.forward,                // Backwards 3 
            -Vector3.forward + Vector3.right, // Right Diagonal Backward 4
            -Vector3.forward - Vector3.right // Left Diagonal Backward 5
        };
    }

    public void Tick()
    {
        if (_isFroze) return;
        
        _body.SetVelocity(_currDirection * (speed * _speedMultiplier));
    }

    public void SetDirection(int index)
    {
        _currDirection = _directions[index];
        _isFroze = false;
    }
    
    public void Throw()
    {
        transform.parent = null;
        SetDirection(0);
    }

    public void Freeze()
    {
        _body.Freeze();
        _isFroze = true;
    }

    public void SetThrowPos(Transform throwPos)
    {
        var selfTransform = transform;
        
        selfTransform.position = throwPos.position;
        selfTransform.parent = throwPos;
    }

    private void OnCollisionHandler(ICollider other)
    {
        if (other.Layer == LayerMask.NameToLayer("Limit"))
        {
           OnRecycle?.Invoke(this);
        }
    }

    public void Recycle()
    {
        OnRecycle?.Invoke(this);
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }
    
    private void OnRecycleHandler(Ball self)
    {
        gameObject.SetActive(false);
    }
}