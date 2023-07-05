using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBody : MonoBehaviour
{
    CustomCollider collider;
    public float velX;
    public float velY;
    Vector3 temp;
    private void Awake()
    {
        collider = GetComponent<CustomCollider>();
    }
    private void Start()
    {
        CustomUpdateManager.Instance.tickeableBodies.Add(this);
    }
    //Suma velocidad
    public void AddVelocity(float inputX = 0, float inputY = 0)
    {
        velX += inputX;
        velY += inputY;
    }
    //Setea velocidad forzadamente
    public void SetVelocity(float x = 0, float y = 0)
    { 
        velX = x;
        velY = y;
    }
    //Frena en seco el objeto
    public void Stop()
    { 
        velX = 0;
        velY = 0;
    }
    //Update
    public void Tick()
    {
        temp = new Vector3(velX, velY, transform.position.z);
        transform.position += temp * Time.deltaTime;
        collider.posX = transform.position.x;
        collider.posY = transform.position.y;
    }
}
