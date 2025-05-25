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
        PlayerData data = player.Data;
        player.SetPlayerData(data.standHeight, data.standSpeed);
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
