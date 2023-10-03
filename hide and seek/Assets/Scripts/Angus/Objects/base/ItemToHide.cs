using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class ItemToHide : MonoBehaviour
{
    protected Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public abstract void Interact();


}
