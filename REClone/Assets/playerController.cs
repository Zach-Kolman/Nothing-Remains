using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private CharacterController rb;

    public float speed = 2;
    public float fallSpeed = -7;
    public float vSpeed = 0;
    public float turnSpeed = 90f;
    public float gravity = 9.8f;
    public float sprintSpeed;
    public float fireSpeed;
    public float gunshotVolumeScale;

    public Animator animator;

    public bool isAiming = false;
    bool isWalking = false;
    bool isSprinting = false;
    public bool isFiring = false;
    bool isPlaying = false;
    public bool isMoving;
    private bool movingBack = false;
    bool startPlaying = false;

    private AudioSource source;

    public AudioClip footSFX1;
    public AudioClip footSFX2;
    public AudioClip fireSound;

    public List<Collider> mobs;

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
            if(mobs.Count > 0)
            {
                gameObject.GetComponent<LookAtEnemy>().lookAtMob();
            }
            isSprinting = false;
            speed = 0;
            turnSpeed = 0;
            movingBack = false;
            
        }

        else
        {
            speed = 2;
            turnSpeed = 45;
        }

       
        animator.SetBool("isAiming", isAiming);
    }

    public Transform GetClosestEnemy()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach(Collider trans in mobs)
        {
            Debug.Log("we got it");
            float dist = Vector3.Distance(trans.transform.position, currentPos);
            if(dist < minDist)
            {
                tMin = trans.transform;
                minDist = dist;
                
            }
        }

        Debug.Log(tMin);
        return tMin;
        
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
        yield return new WaitForSeconds(0.5f);
        isPlaying = false;
        startPlaying = false;
        turnSpeed = 45;
       
        yield return 0;
    }
    void Fire()
    {
        StartCoroutine("SetPlaying");
        if (startPlaying)
        {

            source.clip = fireSound;
            source.PlayOneShot(fireSound, gunshotVolumeScale);
            turnSpeed = 0;
            if ( isAiming)
            {
                //turnSpeed = 0;
                //source.clip = fireSound;
                //source.PlayOneShot(fireSound);
                    //animator.Play("Firing", -1);

                    // source.Stop();
            }

        }
       

       
    }

   
    

    // Update is called once per frame
    void Update()
    {
        mobs = GetComponentInChildren<CheckMobsInRange>().mobsInRange;

        isAiming = Input.GetButton("Aim");

        isSprinting = Input.GetButton("Sprint");

        isFiring = Input.GetButtonDown("FireMain");

        vSpeed = gravity * Time.deltaTime;

        Vector3 moveDir;

        Vector3 vel = transform.up * -10;

        AimDown();

        Sprint();

        CheckIfBack();

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

        animator.SetFloat("fireSpeed", fireSpeed);

        animator.SetBool("movingBack", movingBack);

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

    void CheckIfBack()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            movingBack = false;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            if(!isAiming)
            {
                movingBack = true;
                speed = 1;
            }
               
        }
    }


}
