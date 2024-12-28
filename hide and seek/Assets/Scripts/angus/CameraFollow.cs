using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offsetPos;
    public float moveSpeed;

    private void Update()
    {
        Vector3 targetPos = Target.transform.position + offsetPos;
        transform.localPosition = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
