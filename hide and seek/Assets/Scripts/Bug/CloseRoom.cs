using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRoom : MonoBehaviour
{

    public Renderer closeRoom;
    // Start is called before the first frame update
    void Start()
    {
        closeRoom = GetComponent<Renderer>();
        closeRoom.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            closeRoom.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            closeRoom.enabled = true;
        }

    }
}
