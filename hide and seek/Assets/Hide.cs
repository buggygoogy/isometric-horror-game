using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public PlayerHidingState HidingState;
    public Hideable hidingTarget;

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            if(hidingTarget != null)
            {
                
            }
        }
    }
}
