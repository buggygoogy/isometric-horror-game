using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
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


    private void Start()
    {
        Input = GetComponent<playerInput>();
        controller = GetComponent<CharacterController>();
        currentHealth = playerdata.hp;
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdleState(this));
    }
    private void Update()
    {
        UpdateGravity();
        stateMachine.Update();
    }
    public void Move(Vector2 direction, float speed)
    {
        Vector3 horizontalMove = new Vector3(direction.x, 0f, direction.y) * speed;
        Vector3 move = horizontalMove;

        controller.Move(move * Time.deltaTime);
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
}
