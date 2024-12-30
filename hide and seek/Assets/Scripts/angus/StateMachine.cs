using UnityEngine;

public class StateMachine
{
    [SerializeField]private Istate currentState;
    public void ChangeState(Istate newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
        Debug.Log(currentState);
    }
    public void Update()
    {
        currentState?.Update();
    }
}
