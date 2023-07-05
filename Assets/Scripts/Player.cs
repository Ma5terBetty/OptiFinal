using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameplayElement
{
    CustomCollider collider;
    CustomBody body;
    [SerializeField] float playerSpeed;

    private void Awake()
    {
        collider = GetComponent<CustomCollider>();
        body = GetComponent<CustomBody>();
    }

    private void Start()
    {
        CustomUpdateManager.Instance.tickeableObjects.Add(this);
    }

    public override void Tick()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            body.SetVelocity(-playerSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            body.SetVelocity(playerSpeed);
        }
        else
        { 
            body.Stop();
        }
    }
}
