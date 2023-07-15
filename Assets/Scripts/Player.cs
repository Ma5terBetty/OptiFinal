using System;
using Custom.Physics;
using UnityEngine;
using Custom.UpdateManager;
using Random = UnityEngine.Random;

public class Player : UpdateBehavior, IGameplayUpdate
{
    [SerializeField] private float playerSpeed = 5;

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
        _collider.OnCollision += OnCollisionHandler;
    }

    public void Tick()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _body.SetVelocity(Vector3.right * -playerSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _body.SetVelocity(Vector3.right * playerSpeed);
        }
        else
        { 
            _body.Freeze();
        }
    }

    private void OnCollisionHandler(ICollider other)
    {
        if (other.Layer != LayerMask.NameToLayer("Ball")) return;

        if (!other.Owner.TryGetComponent(out Ball ball)) return;

        var distToCenter = Vector3.Distance(transform.position,other.Position);

        int rnd = Random.Range(2, 3);
        
        ball.SetDirection(distToCenter < 1 ? 1 : rnd);
    }
}
