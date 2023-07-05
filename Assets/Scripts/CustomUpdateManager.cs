using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUpdateManager : MonoBehaviour
{
    public static CustomUpdateManager Instance;

    public List<GameplayElement> tickeableObjects;
    public List<CustomBody> tickeableBodies;

    float Gameplayfrequency = 0.01f;
    float GameplayFrameCounter = 0;

    float timeCounter = 0;
    float frameCounter = 0;

    float debugTime = 5;

    public bool IsPaused { get; set; }

    private void Awake()
    {
        if (CustomUpdateManager.Instance == null)
        {
            CustomUpdateManager.Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        GameplayFrameCounter += Time.deltaTime;
        timeCounter += Time.deltaTime;

        if (IsPaused) return;

        //Cada 0.016 ms ejecuto para respetar los 60 llamados por segundo (aprox)
        if (GameplayFrameCounter >= Gameplayfrequency)
        {
            PhysicsTick();
            GameplayTick();
            GameplayFrameCounter = 0;
            //frameCounter++;
        }


    }
    //Updateo los elementos del Gameplay
    void GameplayTick()
    {
        for (int i = 0; i < tickeableObjects.Count; i++)
        {
            tickeableObjects[i].Tick();
        }
    }

    void PhysicsTick()
    {
        for (int i = 0; i < tickeableBodies.Count; i++)
        {
            tickeableBodies[i].Tick();
        }
    }
}
