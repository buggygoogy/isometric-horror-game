using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switchable : ItemToInteract
{
    public bool Switch;
    public Light _light;
    public float LightPower;

    public float smoothTime;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        _light = transform.GetComponentInChildren<Light>();
        LightPower = _light.intensity;
    }
    public override void Interact()
    {
        StartCoroutine(LightToggle());

    }

    IEnumerator LightToggle()
    {
        float elapsedTime = 0;
        Switch = !Switch;
        while (elapsedTime < smoothTime)
        {
            if(Switch)
            {
                _light.intensity = Mathf.Lerp(_light.intensity, LightPower, (elapsedTime / smoothTime));
            }
            else
            {
                _light.intensity = Mathf.Lerp(_light.intensity, 0, (elapsedTime / smoothTime));
            }
            elapsedTime += Time.deltaTime;
            Debug.Log("TurnLight");
            yield return null;
        }
        yield return null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.InteractItem = this;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.InteractItem = null;
        }
    }
}
