using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHideable
{
    public enum HidingType
    {
        None,
        Bed,
        Cabinet
    }
    void Hide(HidingType _hidingType)
    {

    }
    void UnHide()
    {

    }
}
