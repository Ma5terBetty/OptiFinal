using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay_Elements
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Transform startPos;
        [SerializeField] private Ball ballPrefab;

        private List<Ball> _balls = new List<Ball>();
        private bool _isAbleToThrow;

        public int BallsInWorld => _balls.Count;
        
        private void Start()
        {
            AddBall(startPos.position);
        }

        public void ThrowBall()
        {
            if (!_isAbleToThrow) return;
            
            _balls[0].Throw();
            _isAbleToThrow = false;
        }

        public void AddBall(Vector3 position)
        {
            var newBall = Instantiate(ballPrefab, position, Quaternion.identity);
            newBall.OnDestroyed += Ball_OnDestroyedHandler;
            _balls.Add(newBall);

            if (BallsInWorld == 1)
            {
                Reset();
            }
        }

        public void Reset()
        {
            var ball = _balls[0];
            
            ball.SetThrowPos(startPos);
            ball.Freeze();
            _isAbleToThrow = true;
        }

        private void Ball_OnDestroyedHandler(Ball ball)
        {
            if (BallsInWorld > 1)
            {
                _balls.Remove(ball);
                ball.OnDestroyed -= Ball_OnDestroyedHandler;
                return;
            }
            
            Reset();
        }
    }
}