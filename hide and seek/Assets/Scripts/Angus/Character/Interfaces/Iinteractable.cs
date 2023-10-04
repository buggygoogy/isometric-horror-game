using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteractable 
{
    public ItemToInteract InteractItem { get; set; }
    void ItemInteract();
}
