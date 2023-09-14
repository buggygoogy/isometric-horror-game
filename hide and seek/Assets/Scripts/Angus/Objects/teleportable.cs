using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportable : interactable
{
    public Transform cameraPosition;
    public GameObject camera;



    public override void Interact()
    {
        StartCoroutine(teleportPlayer());
    }

    IEnumerator teleportPlayer()
    {
        camera.transform.position = cameraPosition.position;
        yield break;
    }
    private void OnTriggerEnter(Collider other)
    {
        Interact();
    }
}
