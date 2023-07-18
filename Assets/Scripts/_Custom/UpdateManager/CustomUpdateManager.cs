using System.Collections;
using System.Collections.Generic;
using Custom.Physics;
using UnityEngine;

namespace Custom.UpdateManager
{
    public class CustomUpdateManager : MonoBehaviour
    {
        public static CustomUpdateManager Instance;

        private readonly List<IGameplayUpdate> _gameplayUpdates = new List<IGameplayUpdate>();
        private readonly List<IUIUpdate> _uiUpdates = new List<IUIUpdate>();
        private readonly List<IPhysicsUpdate> _physicsUpdates = new List<IPhysicsUpdate>();

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
            for (var index = 0; index < _uiUpdates.Count; index++)
            {
                var element = _uiUpdates[index];
                element?.Tick();
            }
        }


        //Updateo los elementos del Gameplay
        private void GameplayTick()
        {
            for (var index = 0; index < _gameplayUpdates.Count; index++)
            {
                var element = _gameplayUpdates[index];
                element?.Tick();
            }
        }

        private void PhysicsTick()
        {
            for (var index = 0; index < _physicsUpdates.Count; index++)
            {
                var element = _physicsUpdates[index];
                element?.Tick();
            }
        }

        public void Register(IUpdatable input)
        {
            if (input is IUIUpdate ui)
            {
                _uiUpdates.Add(ui);
            }

            if (input is IGameplayUpdate gameplay)
            {
                _gameplayUpdates.Add(gameplay);
            }

            if (input is IPhysicsUpdate physics)
            {
                _physicsUpdates.Add(physics);
            }
        }
        
        public void Unregister(IUpdatable input)
        {
            if (input is IUIUpdate ui)
            {
                _uiUpdates.Remove(ui);
            }

            if (input is IGameplayUpdate gameplay)
            {
                _gameplayUpdates.Remove(gameplay);
            }

            if (input is IPhysicsUpdate physics)
            {
                _physicsUpdates.Remove(physics);
            }
        }

    }
}

