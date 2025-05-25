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

    public PlayerInputManager playerInput { get; private set; }
    public StateMachine stateMachine { get; private set; }

    float gravity = -9.81f;

    float verticalVelocity = 0f;

    private CharacterController controller;

    private float currentSpeed;

    public Camera MainCamera { get; private set; }

    public Vector2 move { get; private set; }


    private void Start()
    {
        playerInput = FindObjectOfType<PlayerInputManager>();
        controller = GetComponent<CharacterController>();
        MainCamera = Camera.main;
        stateMachine = new StateMachine();
        stateMachine.IntializeState(new StandState(this));
        playerInput.crouchStateInput += ToggleCrouch;
        playerInput.crawlStateInput += ToggleCrawl;
        playerInput.moveInput += HandleMoveInput;
    }

    void OnDisable()
    {
        playerInput.crouchStateInput -= ToggleCrouch;
        playerInput.crawlStateInput -= ToggleCrawl;
        playerInput.moveInput -= HandleMoveInput;
    }
    private void Update()
    {
        UpdateGravity();
        stateMachine.Update();
        Debug.Log(move);
    }

    public void HandleMoveInput(Vector2 _moveInput)
    {
        move = _moveInput;
    }
    public void Move()
    {
        Vector3 moveDirection = GetCameraRelativeDirection(move) * currentSpeed;
        controller.Move(moveDirection * Time.deltaTime);
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
    public void SetPlayerHeight(float height)
    {
        controller.height = height;
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void SetPlayerData(float height, float speed)
    {
        SetPlayerHeight(height);
        SetMovementSpeed(speed);
    }
    public Vector3 GetCameraRelativeDirection(Vector2 inputDirection)
    {
        // 獲取攝影機的朝向向量
        Vector3 cameraForward = MainCamera.transform.forward;
        Vector3 cameraRight = MainCamera.transform.right;

        // 確保方向只在 XZ 平面
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // 計算輸入轉換到世界方向
        return cameraForward * inputDirection.y + cameraRight * inputDirection.x;
    }

    public void RotateTowards()
    {
        Vector3 rotateDirection = GetCameraRelativeDirection(move);
        if (rotateDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotateDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    public void ToggleCrouch() //蹲
    {
        Istate currentState = stateMachine.GetCurrentState();
        if (currentState is StandState)
        {
            stateMachine.ChangeState(new CrouchState(this));
        }
        else if (currentState is CrouchState)
        {
            stateMachine.ChangeState(new StandState(this));
        }
    }
    public void ToggleCrawl() //爬
    {
        Istate currentState = stateMachine.GetCurrentState();
        if (currentState is StandState)
        {
            stateMachine.ChangeState(new CrawlState(this));
        }
        else if (currentState is CrawlState)
        {
            stateMachine.ChangeState(new StandState(this));
        }
    }
}
