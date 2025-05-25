using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{

    public event Action<float> RotateCamera;

    public event Action crouchStateInput;
    public event Action crawlStateInput;

    public event Action<Vector2> moveInput;
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void MoveInput(Vector2 moveDirection)
    {
        moveInput.Invoke(moveDirection);
    }
    public void OnCameraRotate(InputValue value)
    {
        CameraRotationInput(value.Get<float>());
    }

    public void CameraRotationInput(float rotation)
    {
        RotateCamera?.Invoke(rotation);
    }

    public void OnCrouch(InputValue value)
    {
        if (value.isPressed)
        {
            crouchStateInput?.Invoke();
        }
    }

    public void OnCrawl(InputValue value)
    {
        if (value.isPressed)
        {
            crawlStateInput?.Invoke();
        }
    }
    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            // Handle interaction logic here
            Debug.Log("Interact button pressed");
        }
    }
}
