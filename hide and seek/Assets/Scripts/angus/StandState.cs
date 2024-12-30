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
        player.SetMovementSpeed(player.Data.standSpeed);
        player.SetColliderHeight(player.Data.standHeight);
    }

    public void Update()
    {

        Vector2 moveInput = player.Input.move;
        player.Move(moveInput);
        player.RotateDirections(moveInput);
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            player.stateMachine.ChangeState(new CrouchState(player));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.stateMachine.ChangeState(new CrawlState(player));
        }

    }

    public void Exit()
    {

    }
}
