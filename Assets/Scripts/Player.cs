using System.Collections;
using System.Collections.Generic;
using CustomPhysics;
using UnityEngine;
using Collider = CustomPhysics.Collider;

public class Player : GameplayElement
{
    /*CustomCollider collider;
    CustomBody body;*/
     
    
    [SerializeField] private float playerSpeed = 5;

    private Collider _collider;
    private PhysicsBody _body;

    
    private void Awake()
    {
        /*collider = GetComponent<CustomCollider>();
        body = GetComponent<CustomBody>();*/
    }

    private void Start()
    {
        CustomUpdateManager.Instance.tickeableObjects.Add(this);
        
        var selfTransform = transform;
        _collider = new CustomPhysics.BoxCollider(selfTransform,gameObject.tag,gameObject.layer, OnCollisionHandler);
        _body = new PhysicsBody(selfTransform);
    }

    public override void Tick()
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

    private void OnCollisionHandler(Collider other)
    {
        
    }
}
