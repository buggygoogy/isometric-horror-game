using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : ItemToInteract
{
    public bool Switch;
    public new Light light;
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
