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
    public bool startPlaying = false;
    public bool isReloading = false;

    private AudioSource source;

    public AudioClip footSFX1;
    public AudioClip footSFX2;
    public AudioClip fireSound;

    public List<Collider> mobs;

    public Transform closestMob;

    public bool inSight = false;

    GameObject shootCheckBox;

    public bool hasTurned = false;
    // Start is called before the first frame update
    void Start()
    {

        isMoving = false;

        sprintSpeed = 3.5f;

        rb = gameObject.GetComponent<CharacterController>();

        animator = gameObject.GetComponent<Animator>();

        source = GetComponent<AudioSource>();

        shootCheckBox = gameObject.transform.GetChild(8).gameObject;
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
            shootCheckBox.SetActive(true);
            
        }

        else
        {
            speed = 2;
            turnSpeed = 45;
            shootCheckBox.SetActive(false);
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
            //Debug.Log("we got it");
            float dist = Vector3.Distance(trans.transform.position, currentPos);
            if(dist < minDist)
            {
                tMin = trans.transform;
                minDist = dist;
                
            }
        }

        //Debug.Log(tMin);
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
        yield return new WaitForSeconds(0.3f);
        isPlaying = false;
        startPlaying = false;
        turnSpeed = 45;
       
        
    }
    void Fire()
    {

        StartCoroutine("SetPlaying");
        if (inSight && closestMob != null)
        {
            print("hit enemy");
            closestMob.GetComponent<EnemyBase>().gotShot = true;
        }



        if (startPlaying)
        {
           
            {
                source.clip = fireSound;
                source.PlayOneShot(fireSound, gunshotVolumeScale);
                gameObject.GetComponent<AmmoHandler>().curAmmo -= 1;
                turnSpeed = 0;
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        closestMob = GetClosestEnemy();

        mobs = GetComponentInChildren<CheckMobsInRange>().mobsInRange;

        isAiming = Input.GetButton("Aim");

        isReloading = Input.GetButtonDown("Reload");

        isSprinting = Input.GetButton("Sprint");
        if (gameObject.GetComponent<AmmoHandler>().curAmmo > 0)
        {
            isFiring = Input.GetButtonDown("FireMain");
        }

        

        vSpeed = gravity * Time.deltaTime;

        Vector3 moveDir;

        Vector3 vel = transform.up * -10;

        AimDown();

        Sprint();

        CheckIfBack();

        StartCoroutine("TurnAround");

        Reload();

        //Fire();

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        moveDir = transform.forward * Input.GetAxis("Vertical") * speed;

        rb.Move(moveDir * Time.deltaTime);

        if(rb.isGrounded)
        {
            vSpeed = 0;
        }


        rb.Move(vel * Time.deltaTime);

        //Debug.Log(speed);

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

        //Debug.Log(isMoving);
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

    IEnumerator TurnAround()
    {
        if(movingBack && isSprinting)
        {
            if(!hasTurned)
            {
                hasTurned = true;
                transform.Rotate(Vector3.up, 180);
                yield return new WaitForSeconds(2);
                hasTurned = false;
            }

        }
        
    }

    void Reload()
    {
        if(isReloading)
        {
            gameObject.GetComponent<AmmoHandler>().Reload();
        }
    }
}