using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Imoveable
{
    Rigidbody rb { get; set; }

    Vector2 facingDirection { get; set; }

    Vector3 moveVelocity { get; set; }
    float angle { get; set; }

    void PlayerMove(Vector3 velocity);

    void PlayerRotate(Vector2 facingDirection);
}
