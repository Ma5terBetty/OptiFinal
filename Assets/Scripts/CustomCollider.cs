using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCollider : MonoBehaviour
{
    public float posX;
    public float posY;
    public float widht;
    public float height;
    
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        widht = transform.localScale.x;
        height = transform.localScale.y;
    }
    //Offsets para comparar posiciones después
    float GetHeightOffset()
    { 
        return height /2;
    }
    float GetWidthOffset()
    {
        return widht / 2;
    }
}
