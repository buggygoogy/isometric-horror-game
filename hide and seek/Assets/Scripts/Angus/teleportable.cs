using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportable : interactable
{
    public Transform teleportPosition;
    public Transform cameraPosition;
    public GameObject camera;



    public override void Interact()
    {
        StartCoroutine(teleportPlayer());
    }

    IEnumerator teleportPlayer()
    {
        //player.transform.position = new Vector3(teleportPosition.position.x, player.transform.position.y, teleportPosition.position.z);
        camera.transform.position = cameraPosition.position;
        yield break;
    }
    private void OnTriggerEnter(Collider other)
    {
        Interact();
    }
}
