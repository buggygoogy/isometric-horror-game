using UnityEngine;

public class CrouchState : Istate
{
    private PlayerController player;

    public CrouchState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.SetMovementSpeed(player.Data.crouchSpeed);
        player.SetColliderHeight(player.Data.crouchHeight);
    }

    public void Update()
    {
        Vector2 moveInput = player.Input.move;
        player.Move(moveInput);
        player.RotateDirections(moveInput);


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            player.stateMachine.ChangeState(new StandState(player));
        }

        // 切換到趴姿 (Z鍵)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.stateMachine.ChangeState(new CrawlState(player));
        }
    }

    public void Exit()
    {

    }
}
