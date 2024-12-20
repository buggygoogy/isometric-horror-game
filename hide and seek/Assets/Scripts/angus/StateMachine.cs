using UnityEngine;

public class StateMachine
{
    [SerializeField]private Istate currentState;
    public void ChangeState(Istate newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
    public void Update()
    {
        currentState?.Update();
        Debug.Log(currentState);
    }
}
