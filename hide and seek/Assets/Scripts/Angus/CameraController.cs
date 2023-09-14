using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }
    public void ChangeCameraPosition(Transform newPosition)
    {
        this.gameObject.transform.position = newPosition.position;
    }
}
