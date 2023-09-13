using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    public abstract void Interact();

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interact interactObject = other.GetComponent<interact>();
            interactObject.interactObject = this;
            Debug.Log("playerInside");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact interactObject = other.GetComponent<interact>();
            interactObject.interactObject = null;
            Debug.Log("playerOustide");
        }
    }

}
