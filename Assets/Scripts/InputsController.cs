using System;
using Custom.UpdateManager;
using Gameplay_Elements;
using UnityEngine;

public class InputsController : UpdateBehavior, IGameplayUpdate, IPhysicsUpdate
{
    [SerializeField] private Player player;
    [SerializeField] private BallController ballController;

    private bool _hasPlayer;
    private bool _hasBall;

    private void Awake()
    {
        _hasPlayer = player;
        _hasBall = ballController;
    }

    void IGameplayUpdate.Tick()
    {
        if (_hasBall)
        {
            BallController();
        }
    }

    void IPhysicsUpdate.Tick()
    {
        if (_hasPlayer)
        {
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        var value = Input.GetAxisRaw("Horizontal");
        player.Move(value);
    }

    private void BallController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballController.ThrowBall();
        }
    }
}