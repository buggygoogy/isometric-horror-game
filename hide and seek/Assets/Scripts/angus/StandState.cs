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
        Vector3 worldDirection = player.GetCameraRelativeDirection(moveInput);
        player.Move(worldDirection);
        player.RotateTowards(worldDirection);
        
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
