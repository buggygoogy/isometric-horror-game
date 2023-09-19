using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHideable
{
    public bool IsHiding { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Hide(IHideable.HidingType _hidingType)
    {
        throw new System.NotImplementedException();
    }

    public void UnHide()
    {
        throw new System.NotImplementedException();
    }
}
