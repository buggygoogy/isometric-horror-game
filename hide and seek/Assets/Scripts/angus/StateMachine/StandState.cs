using UnityEngine;

public class StandState : Istate
{
    private PlayerController player;

    public StandState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.SetPlayerData(player.Data);
    }

    public void Update()
    {
        if(player.move.sqrMagnitude > 0f)
        {
            player.stateMachine.ChangeState(new MoveState(player));
            return;
        }

    }

    public void Exit()
    {

    }
}
