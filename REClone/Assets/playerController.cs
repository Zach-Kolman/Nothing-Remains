using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private CharacterController rb;

    //public float baseSpeed = 3;

    public float speed = 2;

    public float fallSpeed = -7;

    public float vSpeed = 0;

    public float turnSpeed = 90f;

    public float gravity = 9.8f;

    public Animator animator;

    bool isAiming = false;

    bool isWalking = false;

    bool isSprinting = false;

    public float sprintSpeed;

    public bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;

        sprintSpeed = 3.5f;

        rb = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();


    }

    void AimDown()
    {
        if (isAiming)
        {

            Debug.Log("hi");
            isAiming = true;
            isSprinting = false;
            Debug.Log("thing did");
            speed = 0;

        }

        else
        {
            speed = 2;
        }

       
        animator.SetBool("isAiming", isAiming);
    }

    void Sprint()
    {
        if (isSprinting && speed > 0)
        {
            speed = 3.5f;
            isSprinting = true;

        }

        else
        {
            isSprinting = false;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        isAiming = Input.GetButton("Aim");

        isSprinting = Input.GetButton("Sprint");

        vSpeed = gravity * Time.deltaTime;

        Vector3 moveDir;

        Vector3 vel = transform.up * -10;

        AimDown();

        Sprint();

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        moveDir = transform.forward * Input.GetAxis("Vertical") * speed;

        rb.Move(moveDir * Time.deltaTime);

        if(rb.isGrounded)
        {
            vSpeed = 0;
        }


        rb.Move(vel * Time.deltaTime);

        Debug.Log(speed);

        animator.SetBool("isWalking", isWalking);

        animator.SetBool("isSprinting", isSprinting);
        animator.SetBool("isMoving", isMoving);

        if(Input.GetAxis("Vertical") != 0)
        {
                isMoving = true;
                if(speed < 3)
                {
                    isWalking = true;
                }
            

            if(speed <= 0)
            {
                isMoving = false;
            }
            
        }

        else
        {
            isWalking = false;
            isMoving = false;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            if(speed > 3)
            {
               isSprinting = true;
            }
           
        }

        else
        {
            isSprinting = false;
        }

        if(Input.GetAxis("Vertical") == 0)
        {
            isSprinting = false;
        }

        Debug.Log(isMoving);
    }

}
