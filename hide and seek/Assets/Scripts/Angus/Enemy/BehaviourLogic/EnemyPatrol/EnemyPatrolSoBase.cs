using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolSoBase : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    public virtual void Intialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public virtual void DoEnterLogic()
    {

    }
    public virtual void DoExitLogic()
    {
        ResetValue();
    }
    public virtual void DoFrameUpdateLogic()
    {

    }
    public virtual void DoPhysicsUpdateLogic()
    {

    }
    public virtual void DoAnimationTriggerEvent(Enemy.AnimationTriggerTypes triggerTypes)
    {

    }
    public virtual void ResetValue()
    {

    }
}
