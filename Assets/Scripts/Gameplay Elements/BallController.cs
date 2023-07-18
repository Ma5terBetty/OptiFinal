using System;
using System.Collections.Generic;
using _Custom.Pool;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace Gameplay_Elements
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Transform startPos;
        [SerializeField] private Ball ballPrefab;

        private CustomPool<Ball> _ballsPool;
        private readonly List<Ball> _ballsInWorld = new List<Ball>();
        private bool _isAbleToThrow;

        private void Awake()
        {
            _ballsPool = new CustomPool<Ball>(BallFactoryMethod, isDynamic: false, initialStock: 9);
        }

        private void Start()
        {
            SetBallInThrowPos();
        }

        public void ThrowBall()
        {
            if (!_isAbleToThrow) return;

            _ballsInWorld[0].Throw();
            _isAbleToThrow = false;
        }

        public void AddBall()
        {
            var newBall = _ballsPool.GetObject();
            newBall.OnRecycle += Ball_OnRecycledHandler;
            _ballsInWorld.Add(newBall);
        }

        public void AddBall(Transform newTransform)
        {
            var newBall = _ballsPool.GetObject();
            newBall.OnRecycle += Ball_OnRecycledHandler;
            newBall.transform.position = newTransform.position;
            newBall.SetDirection(3);
            _ballsInWorld.Add(newBall);
        }

        public void RemoveBall(Ball ball)
        {
            ball.Recycle();
        }

        private Ball BallFactoryMethod()
        {
            return Instantiate(ballPrefab);
        }
        
        private void SetBallInThrowPos()
        {
            AddBall();
            _ballsInWorld[0].SetThrowPos(startPos);
            _isAbleToThrow = true;
        }

        private void Ball_OnRecycledHandler(Ball ball)
        {
            ball.OnRecycle -= Ball_OnRecycledHandler;
            _ballsInWorld.Remove(ball);

            if (_ballsInWorld.Count == 0)
            {
                SetBallInThrowPos();
            }
        }
    }
}