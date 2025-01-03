using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerData playerdata;
    public PlayerData Data => playerdata;

    private int currentHealth;

    public playerInput Input { get; private set; }
    public StateMachine stateMachine { get; private set; }

    float gravity = -9.81f;

    float verticalVelocity = 0f;

    private CharacterController controller;

    private float currentSpeed;




    private void Start()
    {
        Input = GetComponent<playerInput>();
        controller = GetComponent<CharacterController>();
        currentHealth = playerdata.hp;
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new StandState(this));
    }
    private void Update()
    {
        UpdateGravity();
        stateMachine.Update();
    }
    public void Move(Vector2 movingDirection)
    {
        Vector3 horizontalMove = new Vector3(movingDirection.x, 0f, movingDirection.y) * currentSpeed;

        controller.Move(horizontalMove * Time.deltaTime);
    }
    public void UpdateGravity()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        Vector3 verticalMove = Vector3.up * verticalVelocity * Time.deltaTime;
        controller.Move(verticalMove);
    }
    public void RotateDirections(Vector2 direction)
    {

        if (direction.sqrMagnitude < 0.001f) return;


        float rotationSpeed = 10f; // 調整旋轉速度

        Vector3 dir3D = new Vector3(direction.x, 0f, direction.y).normalized;
        if (dir3D.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir3D, Vector3.up);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                Time.deltaTime * rotationSpeed
            );
        }
    }
    public void SetColliderHeight(float height)
    {
        controller.height = height;
        // controller.center = new Vector3(0, height / 2f, 0);
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
