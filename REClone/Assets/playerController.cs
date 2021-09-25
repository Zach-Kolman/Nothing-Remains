using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private CharacterController rb;

    public float speed = 4;

    public float fallSpeed = -7;

    public float vSpeed = 0;

    public float turnSpeed = 90f;

    public float gravity = 9.8f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        vSpeed = gravity * Time.deltaTime;

        Vector3 moveDir;

        Vector3 vel = transform.up * -10;           

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        moveDir = transform.forward * Input.GetAxis("Vertical") * speed;

        rb.Move(moveDir * Time.deltaTime);

        if(rb.isGrounded)
        {
            vSpeed = 0;
        }


        rb.Move(vel * Time.deltaTime);
    }
}
