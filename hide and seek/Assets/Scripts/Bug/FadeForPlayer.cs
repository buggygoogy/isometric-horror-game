using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeForPlayer : MonoBehaviour
{
    private ObjectFade _fader;

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if(Player != null)
        {
            Vector3 dir = Player.transform.position - transform.position;
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider == null)
                    return;
                if(hit.collider.gameObject == Player)
                {
                    //沒東西擋住玩家
                    if(_fader != null)
                    {
                        _fader.DoFade = false;
                    }
                }
                else
                {
                    _fader = hit.collider.gameObject.GetComponent<ObjectFade>();
                    if(_fader != null)
                    {
                        _fader.DoFade = true;
                    }
                }
            }
        }
    }
}
