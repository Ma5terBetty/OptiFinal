using System;
using System.Collections;
using System.Collections.Generic;
using Custom.Physics;
using Custom.UpdateManager;
using UnityEngine;
using Collider = UnityEngine.Collider;

public class Box : UpdateBehavior, IGameplayUpdate
{
    private ICollider _collider;

    private void Awake()
    {
        _collider = GetComponent<ICollider>();
    }
    void Start()
    {
        _collider.OnCollision += OnCollisionHandler;
    }
    public void Tick()
    {
    }
    void OnCollisionHandler(ICollider other)
    {
        Debug.Log("Me ha chocado la bola");
        
        gameObject.SetActive(false);
    }

}
