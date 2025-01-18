using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public Vector2 move;

    public float cameraRotation;
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void MoveInput(Vector2 moveDirection)
    {
        move = moveDirection;
    }
    public void OnCameraRotate(InputValue value)
    {
        CameraRotationInput(value.Get<float>());
    }

    public void CameraRotationInput(float rotation)
    {
        cameraRotation = rotation;
    }
}
