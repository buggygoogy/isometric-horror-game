using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemToInteract : MonoBehaviour
{
    public IEnumerator ResetTrigger()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider>().isTrigger = true;
        yield break;
    }
    public abstract void Interact();
}
