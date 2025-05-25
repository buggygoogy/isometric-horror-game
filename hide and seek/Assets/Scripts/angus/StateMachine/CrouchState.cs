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
        
    }

    public void Update()
    {
        if (player.move.sqrMagnitude > 0f)
        {
            player.Move();
            player.RotateTowards();
        }
    }

    public void Exit()
    {

    }
}
