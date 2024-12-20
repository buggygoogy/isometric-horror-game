using Unity;
using UnityEngine;

public class MoveState : Istate
{
    private PlayerController player;

    public MoveState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {

    }

    public void Update()
    {
        Vector2 moveInput = player.Input.move;
        player.Move(moveInput, player.Data.walkSpeed);

        if (moveInput.sqrMagnitude == 0f)
        {
            player.stateMachine.ChangeState(new IdleState(player));
        }
    }

    public void Exit()
    {

    }
}
