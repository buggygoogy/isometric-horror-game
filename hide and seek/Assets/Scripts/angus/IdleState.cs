using UnityEngine;

public class IdleState : Istate
{
    private PlayerController player;

    public IdleState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {

    }

    public void Update()
    {
        Debug.Log(player.Input.move.sqrMagnitude);
        if (player.Input.move.sqrMagnitude > 0f)
        {
            player.stateMachine.ChangeState(new MoveState(player));
        }
    }

    public void Exit()
    {

    }
}
