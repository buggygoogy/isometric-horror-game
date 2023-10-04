using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Player : MonoBehaviour, IHideable, IDamageable, Imoveable, Iinteractable
{
    [field:SerializeField] public bool IsHiding { get; set ; }
    public int Hp { get ; set; }
    public int currentHp { get; set; }
    public Rigidbody rb { get ; set ; }

    [field: SerializeField] public Vector2 facingDirection { get; set; }

    [field: SerializeField] public Vector3 moveVelocity { get; set; }

    public float angle { get ; set ; }

    [field: SerializeField] public IHideable.HidingType _hiding { get; set; }

    public float walkSpeed = 3;


    [field:SerializeField]public HideableObject hidingTarget { get; set; }
    [field:SerializeField]public float delayTimeToToggleHide { get; set; }

    #region StateMachineVariables
    public PlayerStateMachine stateMachine { get; set; }
    public PlayerIdleState IdleState { get; set; }
    public PlayerWalkState WalkState { get; set; }
    public PlayerRunState RunState { get; set; }
    public PlayerHidingState HidingState { get; set; }
    [field: SerializeField] public ItemToInteract InteractItem { get; set; }

    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, stateMachine);
        WalkState = new PlayerWalkState(this, stateMachine);
        RunState = new PlayerRunState(this, stateMachine);
        HidingState = new PlayerHidingState(this, stateMachine);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        stateMachine.currentPlayerState.FrameUpdate();
        moveVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        facingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        stateMachine.currentPlayerState.PhysicsUpdate();
    }



    public void SetHide(IHideable.HidingType _hidingType)
    {
        _hiding = _hidingType;

    }

    public void SetUnHide(IHideable.HidingType _hidingType)
    {
        _hiding = _hidingType;
    }

    public void Damage()
    {

    }

    public void Die()
    {

    }

    public void PlayerRotate(Vector2 facingDirection)
    {
        angle = Mathf.Atan2(facingDirection.x, facingDirection.y);
        angle = Mathf.Rad2Deg * angle;
        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }

    public void PlayerMove(Vector3 moveVelocity)
    {
        rb.velocity = moveVelocity * walkSpeed;
    }
    public void ItemInteract()
    {
        if(InteractItem != null)
        {
            InteractItem.Interact();
        }
    }

    #region AnimationTriggerTypes

    public void AnimationTriggerEvent(AnimationTriggerTypes triggerType)
    {
        stateMachine.currentPlayerState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerTypes
    {
        Idle,
        Walk,
        Run,
        Hide,
        UnHide,

    }

    #endregion
}
