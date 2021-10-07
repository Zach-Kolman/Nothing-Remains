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
    //private NavMeshAgent agent;
    //private Vector3 prevAgentPos;
    private float parentSpeed = 0;
    public float distanceFromPlayer;
    private float playerDist;
    public enum distState
    {
        Wandering,
        Chasing,
        Attacking,
    }
    public distState curState;

   
    // Start is called before the first frame update
    void Start()
    {
        print("hi");
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        poseSpeed = 0;
        anim = GetComponent<Animator>();
       //agent = transform.parent.GetComponent<NavMeshAgent>();
        curHealth = maxHealth;
        //GetDistanceFromPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //print("PlayerDist is: " + playerDist);
        distanceFromPlayer = playerDist;
        SwitchStates();
        //SetStates();
        takeDamage();
        StartCoroutine("die");
        GetDistanceFromPlayer();
    }

    private void FixedUpdate()
    {
        parentSpeed = transform.parent.GetComponent<CheckNMAVel>().velly;
        anim.SetFloat("PoseSpeed", value: poseSpeed);
    }

    public void takeDamage()
    {
        if(gotShot)
        {
            StartCoroutine("PlayHitAnim");
            print("ow");
            curHealth = curHealth - 8;
            gotShot = false;
            
        }
    }

    IEnumerator PlayHitAnim()
    {
        transform.parent.GetComponent<NavMeshAgent>().speed = 0;
        poseSpeed = 1;
        yield return new WaitForSeconds(1);
        
            transform.parent.GetComponent<NavMeshAgent>().speed = 1;
            poseSpeed = 0.5f;
        

       
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(1);
        if(curHealth <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
       
    }

    void GetDistanceFromPlayer()
    {
        playerDist = Vector3.Distance(transform.position, player.transform.position);
    }

    void SwitchStates()
    {
        if(playerDist <= 2.5)
        {
            print("take that scum");
        }

        if(playerDist <= 10)
        {
            print("run bish");
        }

        if(playerDist > 14)
        {
            gameObject.transform.parent.GetComponent<ChasePlayer>().WanderAround();
            print("poopy wandering");
        }
    }

    void ChasePlayer()
    {
        gameObject.GetComponent<ChasePlayer>().ChaseThePlayer();
    }

    //void SetStates()
    //{
    //    if(playerDist <= 2)
    //    {
    //        curState = distState.Attacking;
    //    }

    //    if (playerDist <= 7)
    //    {
    //        curState = distState.Chasing;
    //    }

    //    if (playerDist > 7)
    //    {
    //        curState = distState.Wandering;
    //    }
    //}
}
