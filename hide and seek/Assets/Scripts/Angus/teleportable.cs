using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportable : interactable
{
    public Transform teleportPosition;
    public Transform cameraPosition;

    public GameObject player;
    public GameObject camera;



    public override void Interact()
    {
        StartCoroutine(teleportPlayer());
    }

    IEnumerator teleportPlayer()
    {
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.transform.position = new Vector3(teleportPosition.position.x, player.transform.position.y, teleportPosition.position.z);
        camera.transform.position = cameraPosition.position;
        player.GetComponent<CapsuleCollider>().enabled = true;
        yield break;
    }

}
