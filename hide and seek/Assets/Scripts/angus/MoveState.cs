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

        if (moveInput.sqrMagnitude == 0f)
        {
            player.stateMachine.ChangeState(new StandState(player));
        }

        // 計算攝影機相對的移動方向
        Vector3 worldDirection = player.GetCameraRelativeDirection(moveInput);

        // 移動角色
        player.Move(worldDirection);

        // 角色面向移動方向
        player.RotateTowards(worldDirection);
    }

    public void Exit()
    {

    }
}
