using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Player : MonoBehaviour,  IDamageable, Iinteractable
{
    [field: SerializeField] public bool IsHiding { get; set; } = false;
    public int Hp { get ; set; }
    public int currentHp { get; set; }
    public Rigidbody rb { get ; set ; }

    [field: SerializeField] public float angle { get; set; }

    [field: SerializeField] public HideableObject hidingTarget { get; set; }
    [field:SerializeField] public float delayTimeToToggleHide { get; set; }

    public enum HidingType
    {
        None,
        Bed,
        Cabinet
    }

    public HidingType _hiding;

    [field:SerializeField] public ItemToInteract InteractItem { get; set; }

    #region StateMachineVariables
    public PlayerStateMachine stateMachine { get; set; }
    public PlayerIdleState IdleState { get; set; }
    public PlayerHidingState HidingState { get; set; }

    #endregion

    private void Awake()
    {

        stateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, stateMachine);
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
    }

    private void FixedUpdate()
    {
        stateMachine.currentPlayerState.PhysicsUpdate();
    }



    public void SetHide(HidingType _hidingType)
    {
        _hiding = _hidingType;
    }

    public void SetUnHide(HidingType _hidingType)
    {
        _hiding = _hidingType;
    }

    public void PlayerRotate(Vector2 facingDirection)
    {
        angle = Mathf.Atan2(facingDirection.x, facingDirection.y);
        angle = Mathf.Rad2Deg * angle;
        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }

    public void PlayerMove(Vector3 moveVelocity, float walkSpeed)
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

    public void Damage()
    {

    }

    public void Die()
    {

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
