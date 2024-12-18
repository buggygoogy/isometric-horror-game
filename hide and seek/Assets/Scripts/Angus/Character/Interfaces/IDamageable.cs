using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int Hp { get; set; }

    int currentHp { get; set; }

    void Damage();
    void Die();
}
