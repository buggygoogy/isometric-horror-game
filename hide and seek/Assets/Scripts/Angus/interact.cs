using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    public float distance;
    public LayerMask interactMask;

    public interactable interactObject;
    RaycastHit hit;


    private void Update()
    {
        CheckInteractRaycast();
        if(Input.GetKeyDown(KeyCode.E))
        {
            interactObject.Interact();
        }
    }
    public void CheckInteractRaycast()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * distance));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * distance));
        if(Physics.Raycast(theRay, out hit,interactMask))
        {
            if(hit.transform.GetComponent<interactable>() != false)
            {
                interactObject = hit.transform.GetComponent<interactable>();
            }
        }
    }
    public void OpenInteractIcon()
    {

    }
    public void CloseInteractIcon()
    {

    }
}
