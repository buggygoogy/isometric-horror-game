using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableObject : ItemToHide
{
    public enum HidingType
    {
        Bed,
        Cabinet
    }
    [SerializeField] HidingType type;

    public override void Interact()
    {
        switch (type)
        {
            case HidingType.Bed:
                player.SetHide(IHideable.HidingType.Bed);
                break;
            case HidingType.Cabinet:
                player.SetHide(IHideable.HidingType.Cabinet);
                break;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.hidingTarget = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.hidingTarget = null;
        }
    }

}
