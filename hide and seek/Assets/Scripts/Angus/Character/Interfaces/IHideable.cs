using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHideable
{

    bool IsHiding { get; set; }

    public HideableObject hidingTarget { get; set; }

    public float delayTimeToToggleHide { get; set; }
    public enum HidingType
    {
        None,
        Bed,
        Cabinet
    }
    void SetHide(HidingType _hidingType);
    void SetUnHide(HidingType _hidingType);

}
