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

    private CharacterController controller;

    private float gravity = -9.81f;
    private float verticalVelocity = 0f;
    public bool Grounded = true;

    public float GroundedOffset = -0.14f;

    public float GroundedRadius = 0.28f;
    public LayerMask GroundLayers;


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
        stateMachine.Update();
    }

    public void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
                transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        if (Grounded)
        {
            verticalVelocity = 0f; // 回到地面時重設垂直速度
        }
        else
        {
            // 如果不在地面上，受重力影響
            verticalVelocity += gravity * Time.deltaTime;
        }
    }
    public void Move(Vector2 direction, float speed)
    {
        Vector3 horizontalMove = new Vector3(direction.x, 0f, direction.y) * speed;
        Vector3 move = horizontalMove + Vector3.up * verticalVelocity;

        controller.Move(move * Time.deltaTime);
    }
}
