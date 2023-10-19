using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IAggroCheckable
{

    public NavMeshAgent Agent;

    [field:SerializeField] public bool isAggroed { get ; set ; }
    public bool isWithStrikingDistance { get ; set ; }

    #region StateMachineVariables
    public EnemyStateMachine stateMachine { get; set; }
    public EnemyPatrolState PatrolState { get; set; }
    public EnemyIdleState IdleState { get; set; }

    public EnemyChaseState ChaseState { get; set; }

    #endregion

    #region ScriptableObject variables

    [SerializeField] private EnemyIdleSoBase EnemyIdleBase;
    [SerializeField] private EnemyPatrolSoBase EnemyPatrolBase;
    [SerializeField] private EnemyChaseSoBase EnemyChaseBase;

    public EnemyIdleSoBase EnemyIdleBaseInstance { get; set; }
    public EnemyChaseSoBase EnemyChaseBaseInstance { get; set; }
    public EnemyPatrolSoBase EnemyPatrolBaseInstance { get; set; }

    #endregion

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();

        EnemyIdleBaseInstance = Instantiate(EnemyIdleBase);
        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);
        EnemyPatrolBaseInstance = Instantiate(EnemyPatrolBase);

        stateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, stateMachine);
        PatrolState = new EnemyPatrolState(this, stateMachine);
        ChaseState = new EnemyChaseState(this, stateMachine);
    }

    private void Start()
    {
        stateMachine.Initialize(IdleState);
        EnemyIdleBaseInstance.Intialize(gameObject, this);
        EnemyChaseBaseInstance.Intialize(gameObject, this);
        EnemyPatrolBaseInstance.Intialize(gameObject, this);
    }

    private void Update()
    {
        stateMachine.currentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentEnemyState.PhysicsUpdate();
    }

    public void MoveEnemy(Vector3 target)
    {
        Agent.SetDestination(target);
    }



    public void SetAggroStatus(bool _isAggroed)
    {
        isAggroed = _isAggroed;
    }

    public void SetStrikingDistance(bool isWithStrikingDistance)
    {
        
    }


    #region AnimationTriggerTypes

    public void AnimationTriggerEvent(AnimationTriggerTypes triggerType)
    {
        stateMachine.currentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerTypes
    {
        Idle,
        Walk,
        Hide,
        UnHide

    }

    #endregion
}
