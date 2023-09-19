using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class move : MonoBehaviour
{
    public Rigidbody rb;
    public int walkSpeed;
    public float angle;

    public Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (Mathf.Abs(direction.x) < 1 && Mathf.Abs(direction.y) < 1) return;

        InputToRotate();
    }
    void GetInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        InputToMove();
    }

    void InputToRotate()
    {
        angle = Mathf.Atan2(direction.x, direction.y);
        angle = Mathf.Rad2Deg * angle;
        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }

    void InputToMove()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        rb.velocity = moveDirection * walkSpeed;
    }
}
