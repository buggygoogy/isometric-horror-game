using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleSOBase : ScriptableObject
{
    protected Player player;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    public virtual void Intialize(GameObject gameObject, Player player)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.player = player;

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
    public virtual void DoAnimationTriggerEvent(Player.AnimationTriggerTypes triggerTypes)
    {

    }
    public virtual void ResetValue()
    {

    }
}
