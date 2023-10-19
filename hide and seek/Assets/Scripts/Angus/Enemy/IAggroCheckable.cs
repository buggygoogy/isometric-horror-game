using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAggroCheckable
{
    bool isAggroed { get; set; }
    bool isWithStrikingDistance { get; set; }
    void SetAggroStatus(bool isAggroed);
    void SetStrikingDistance(bool isWithStrikingDistance);
}
