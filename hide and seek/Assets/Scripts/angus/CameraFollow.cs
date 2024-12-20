using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 targetPos;
    public Vector3 offsetPos;
    public GameObject _Camera;
    public float moveSpeed;

    private void Update()
    {
        targetPos = Target.transform.position + offsetPos;
        _Camera.transform.localPosition = Vector3.Lerp(_Camera.transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
