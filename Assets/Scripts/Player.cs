using System;
using Custom.Physics;
using UnityEngine;
using Custom.UpdateManager;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5;

    private ICollider _collider;
    private IBody _body;
    private bool _hasBody;

    private void Awake()
    {
        _collider = GetComponent<ICollider>();
        _body = GetComponent<IBody>();


        _hasBody = _body != null;
        
        if (_collider != null)
        {
            _collider.OnCollision += OnCollisionHandler;
        }
    }

    public void Move(float input)
    {
        if (!_hasBody) return;
        
        _body.SetVelocity(Vector3.right * (playerSpeed * input));
    }

    private void OnCollisionHandler(ICollider other)
    {
        if (other.Layer != LayerMask.NameToLayer("Ball")) return;

        if (!other.Owner.TryGetComponent(out Ball ball)) return;

        var distToCenter = Vector3.Distance(transform.position,other.Position);

        int rnd = Random.Range(1, 2);
        
        ball.SetDirection(distToCenter < 1 ? 0 : rnd);
    }
}
