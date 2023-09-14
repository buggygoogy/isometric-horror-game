using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : interactable
{
    public bool Switch;
    public Light light;
    public override void Interact()
    {
        Switch = !Switch;
        if (Switch)
        {
            light.intensity = 2;
        }
        else
        {
            light.intensity = 0;
        }

    }
}
