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

    bool isFiring = false;

    bool isPlaying = false;

    public float sprintSpeed;

    public bool isMoving;

    private AudioSource source;

    public AudioClip footSFX1;

    public AudioClip footSFX2;

    public AudioClip fireSound;

    bool startPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;

        sprintSpeed = 3.5f;

        rb = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();

        source = gameObject.GetComponent<AudioSource>();


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

    IEnumerator SetPlaying()
    {
        startPlaying = true;
        isPlaying = true;
        yield return new WaitForSeconds(0.25f);
        isPlaying = false;
        startPlaying = false;
       
        yield return 0;
    }
    void Fire()
    {
        StartCoroutine("SetPlaying");
        if (startPlaying)
        {
            
            if ( isAiming)
            {
                   source.clip = fireSound;
                   source.PlayOneShot(fireSound);
                    //animator.Play("Firing", -1);

                    // source.Stop();
            }
        }
       

       
    }

   
    

    // Update is called once per frame
    void Update()
    {
        isAiming = Input.GetButton("Aim");

        isSprinting = Input.GetButton("Sprint");

        isFiring = Input.GetButtonDown("FireMain");

        vSpeed = gravity * Time.deltaTime;

        Vector3 moveDir;

        Vector3 vel = transform.up * -10;

        AimDown();

        Sprint();

        //Fire();

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

        animator.SetBool("isFiring", isFiring);

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

    public void Footstep1()
    {
        source.clip = footSFX1;
        source.Play();
    }

    public void Footstep2()
    {
        source.clip = footSFX2;
        source.Play();
    }

}
