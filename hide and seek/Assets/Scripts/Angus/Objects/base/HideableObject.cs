using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableObject : ItemToHide
{
    [SerializeField] private Material Normal_material;
    [SerializeField] private Material HighLight_material;

    public Renderer render;
    public enum HidingType
    {
        Bed,
        Cabinet
    }
    [SerializeField] HidingType type;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        render = GetComponent<Renderer>();
    }

    public override void Interact()
    {
        switch (type)
        {
            case HidingType.Bed:
                player.SetHide(Player.HidingType.Bed);
                break;
            case HidingType.Cabinet:
                player.SetHide(Player.HidingType.Cabinet);
                break;

        }

    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            render.material = HighLight_material;
            player.hidingTarget = this;
        }
    }
    public override void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            render.material = Normal_material;
            player.hidingTarget = null;
        }
    }

}
