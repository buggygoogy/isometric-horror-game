using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class interactable : MonoBehaviour
{

    public IEnumerator ResetTrigger()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider>().isTrigger = true;
        yield break;
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
