using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Hideable : MonoBehaviour
{
    protected Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();

    }
    public enum HidingType
    {
        None,
        Bed,
        Cabinet
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Hide>().hidingTarget = this;
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        player.GetComponent<Hide>().hidingTarget = null;
    }


}
