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
        player.Move();
        player.RotateTowards();
        if (player.move.sqrMagnitude > 0f)
        {
            return;
        }
        else
        {
            player.stateMachine.ChangeState(new StandState(player));
        }
    }

    public void Exit()
    {

    }
}
