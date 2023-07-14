using System.Collections;
using System.Collections.Generic;
using Custom.Physics;
using UnityEngine;

namespace Custom.UpdateManager
{
    public class CustomUpdateManager : MonoBehaviour
    {
        public static CustomUpdateManager Instance;
        [field: SerializeField] public List<UIElement> UIElements { get; private set; }
        [field: SerializeField] public List<GameplayElement> GameplayElements { get; private set; }
        [field: SerializeField] public List<PhysicsElement> PhysicsElements { get; private set; }

        float Gameplayfrequency = 0.01f;
        float GameplayFrameCounter = 0;

        float timeCounter = 0;
        float frameCounter = 0;

        float debugTime = 5;

        public bool IsPaused { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
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
                UITick();
                GameplayFrameCounter = 0;
                //frameCounter++;
            }
        }
        
        private void UITick()
        {
            foreach (var element in UIElements)
            {
                element.Tick();
            }
        }


        //Updateo los elementos del Gameplay
        private void GameplayTick()
        {
            foreach (var element in GameplayElements)
            {
                element.Tick();
            }
        }

        private void PhysicsTick()
        {
            foreach (var element in PhysicsElements)
            {
                element.Tick();
            }
        }

        #region UI

        public void AddUIElement(UIElement element)
        {
            UIElements ??= new List<UIElement>();

            if (UIElements.Contains(element)) return;
            
            UIElements.Add(element);
        }
        
        public void RemoveUIElement(UIElement element)
        {
            if (!UIElements.Contains(element)) return;
            
            UIElements.Remove(element);
        }

        #endregion

        #region Gameplay

        public void AddGameplayElement(GameplayElement element)
        {
            GameplayElements ??= new List<GameplayElement>();

            if (GameplayElements.Contains(element)) return;

            GameplayElements.Add(element);
        }

        public void RemoveGameplayElement(GameplayElement element)
        {
            if (!GameplayElements.Contains(element)) return;

            GameplayElements.Remove(element);
        }

        #endregion

        #region Physics

        public void AddPhysicsElement(PhysicsElement element)
        {
            PhysicsElements ??= new List<PhysicsElement>();

            if (PhysicsElements.Contains(element)) return;

            PhysicsElements.Add(element);
        }

        public void RemovePhysicsElement(PhysicsElement element)
        {
            if (!PhysicsElements.Contains(element)) return;

            PhysicsElements.Remove(element);
        }

        #endregion

    }
}

