using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : ItemToInteract
{
    public Transform TargetPosition;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void Interact()
    {
        player.transform.position = TargetPosition.position;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.InteractItem = this;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.InteractItem = null;
        }
    }
}
