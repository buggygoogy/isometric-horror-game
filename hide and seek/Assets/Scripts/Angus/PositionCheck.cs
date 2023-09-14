using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCheck : MonoBehaviour
{
    public GameObject groundCheck;
    public LayerMask groundLayer;

    float distance = 1;

    RaycastHit hit;

    private void Update()
    {
        Vector3 direction = Vector3.down;
        Ray theRay = new Ray(groundCheck.transform.position, transform.TransformDirection(direction * distance));
        Debug.DrawRay(groundCheck.transform.position, transform.TransformDirection(direction * distance));
    }
}
