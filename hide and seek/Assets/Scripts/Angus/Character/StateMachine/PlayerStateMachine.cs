using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentPlayerState { get; set; }

    public void Initialize(PlayerState startingState)
    {
        currentPlayerState = startingState;
        currentPlayerState.EnterState();
    }
    public void ChangeState(PlayerState newState)
    {
        currentPlayerState.ExitState();
        currentPlayerState = newState;
        currentPlayerState.EnterState();
        Debug.Log(currentPlayerState.ToString());
    }
}
