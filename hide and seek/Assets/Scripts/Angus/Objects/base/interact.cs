using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    public float distance;

    public ItemToInteract interactObject;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(interactObject != null)
            {
                interactObject.Interact();
            }
        }
    }
}
