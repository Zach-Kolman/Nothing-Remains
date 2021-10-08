using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public bool gotShot = false;
    GameObject player;
    private float poseSpeed;
    private Animator anim;
    private NavMeshAgent agent;
    private Vector3 prevAgentPos;
    private float parentSpeed = 0;
    public float distanceFromPlayer;
    private float playerDist;
    public string stateText;

    // Start is called before the first frame update
    void Start()
    {
        print("hi");
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        poseSpeed = 0;
        anim = GetComponent<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        curHealth = maxHealth;
        distanceFromPlayer = playerDist;
        GetDistanceFromPlayer();
        SwitchStates();
    }

    // Update is called once per frame
    void Update()
    {
        //print("PlayerDist is: " + playerDist);
        distanceFromPlayer = playerDist;
        takeDamage();
        die();
        SwitchStates();
        GetDistanceFromPlayer();
        
    }

    private void FixedUpdate()
    {
        parentSpeed = transform.parent.GetComponent<CheckNMAVel>().velly;
        anim.SetFloat("PoseSpeed", poseSpeed);
    }

    public void takeDamage()
    {
        if(gotShot)
        {
            //StartCoroutine("PlayHitAnim");
            print("ow");
            curHealth = curHealth - 8;
            gotShot = false;
            
        }
    }

    IEnumerator PlayHitAnim()
    {
        gameObject.GetComponent<NavMeshAgent>().speed = 0;
        poseSpeed = 1;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<NavMeshAgent>().speed = 1;
        poseSpeed = 0.5f;
        print("booba");
        

       
    }

    void die()
    {
        if(curHealth <= 0)
        {
            gameObject.SetActive(false);
        }
       
    }

    void GetDistanceFromPlayer()
    {
        playerDist = Vector3.Distance(transform.position, player.transform.position);
    }

    void SwitchStates()
    {
        if(playerDist <= 3)
        {
            gameObject.GetComponent<ChasePlayer>().isAttacking = true;
            gameObject.GetComponent<ChasePlayer>().isWandering = false;
            gameObject.GetComponent<ChasePlayer>().isChasing = false;
            gameObject.GetComponent<FacePlayer>().isFacing = true;
        }
        

        else if(playerDist <= 10)
        {
            gameObject.GetComponent<ChasePlayer>().isAttacking = false;
            gameObject.GetComponent<ChasePlayer>().isChasing = true;
            gameObject.GetComponent<FacePlayer>().isFacing = true;
            gameObject.GetComponent<ChasePlayer>().isWandering = false;
        }

        else if (playerDist >= 11)
        {
            gameObject.GetComponent<ChasePlayer>().isAttacking = false;
            gameObject.GetComponent<ChasePlayer>().isWandering = true;
            gameObject.GetComponent<ChasePlayer>().isChasing = false;
            gameObject.GetComponent<FacePlayer>().isFacing = false;
        }
    }

    //void ChasePlayer()
    //{
    //    gameObject.GetComponent<ChasePlayer>().ChaseThePlayer();
    //    gameObject.GetComponent<FacePlayer>().isFacing = true;
    //}
}
