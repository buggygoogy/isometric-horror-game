using UnityEngine;

public class CrawlState : Istate
{
    private PlayerController player;

    public CrawlState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.SetMovementSpeed(player.Data.crawlSpeed);
        player.SetColliderHeight(player.Data.crawlHeight);
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
            player.stateMachine.ChangeState(new StandState(player));
        }
    }

    public void Exit()
    {

    }
}
