using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public Vector2 move;
    public Vector2 look;
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        LookInput(value.Get<Vector2>());
    }

    public void MoveInput(Vector2 moveDirection)
    {
        move = moveDirection;
    }
    public void LookInput(Vector2 lookDirection)
    {
        look = lookDirection;
    }
}
