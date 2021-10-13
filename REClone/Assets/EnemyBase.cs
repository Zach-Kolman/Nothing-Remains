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
    private float stateSpeed;
    private Animator anim;
    private NavMeshAgent agent;
    //private Vector3 prevAgentPos;
    //private float parentSpeed = 0;
    public float distanceFromPlayer;
    private float playerDist;
    public string stateText;
    private bool dead = false;
    public bool wasHit = false;
    public GameObject hitColl;
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        print("hi");
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        stateSpeed = 0;
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
        anim.SetBool("isDead", dead);
        anim.SetBool("wasHit", wasHit);

    }

    private void FixedUpdate()
    {
        //parentSpeed = transform.parent.GetComponent<CheckNMAVel>().velly;
        anim.SetFloat("States", stateSpeed);
    }

    public void takeDamage()
    {
        float prevSpeed = stateSpeed;
        if(gotShot)
        {
            stateSpeed = 0.4f;
            StartCoroutine("PlayHitAnim");
            print("ow");
            curHealth = curHealth - 8;
            gotShot = false;
            stateSpeed = prevSpeed;
            
        }
    }

    IEnumerator PlayHitAnim()
    {
            agent.speed = 0;
            wasHit = true;
            stateSpeed = 0.4f;
            yield return new WaitForSeconds(1);
            //agent.speed = curVel;
            wasHit = false;
  
    }

    void die()
    {
        if(curHealth <= 0)
        {
            dead = true;
            //stateSpeed = 0.8f;
            agent.speed = 0;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<FacePlayer>().enabled = false;
        }
       
    }

    void GetDistanceFromPlayer()
    {
        playerDist = Vector3.Distance(transform.position, player.transform.position);
    }

    void SwitchStates()
    {
        if(!dead)
        {
            if (playerDist <= 2.25)
            {
                stateSpeed = 0.6f;
                gameObject.GetComponent<ChasePlayer>().isAttacking = true;
                gameObject.GetComponent<ChasePlayer>().isWandering = false;
                gameObject.GetComponent<ChasePlayer>().isChasing = false;
                gameObject.GetComponent<FacePlayer>().isFacing = true;
            }


            else if (playerDist <= 10)
            {
                stateSpeed = 0.8f;
                gameObject.GetComponent<ChasePlayer>().isAttacking = false;
                gameObject.GetComponent<ChasePlayer>().isChasing = true;
                gameObject.GetComponent<FacePlayer>().isFacing = true;
                gameObject.GetComponent<ChasePlayer>().isWandering = false;
            }

            else if (playerDist >= 11)
            {
                stateSpeed = 0.2f;
                gameObject.GetComponent<ChasePlayer>().isAttacking = false;
                gameObject.GetComponent<ChasePlayer>().isWandering = true;
                gameObject.GetComponent<ChasePlayer>().isChasing = false;
                gameObject.GetComponent<FacePlayer>().isFacing = false;
            }
        }
    }

    //void ChasePlayer()
    //{
    //    gameObject.GetComponent<ChasePlayer>().ChaseThePlayer();
    //    gameObject.GetComponent<FacePlayer>().isFacing = true;
    //}

    public void CollActive()
    {
        hitColl.SetActive(true);
    }

    public void CollInactive()
    {
        hitColl.SetActive(false);
    }

    public IEnumerator PlayAttackAnim()
    {
        isAttacking = true;
        stateSpeed = 0.6f;
        yield return new WaitForSeconds(1);
        //agent.speed = curVel;
        isAttacking = false;
    }
}
