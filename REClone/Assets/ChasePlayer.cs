using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    private GameObject player;
    NavMeshAgent agent;
    public GameObject randoChecker;
    public bool isWandering = false;
    public bool isChasing = false;
    public GameObject chasePoint;
    public bool seekSpotFired = false;
    public bool isAttacking = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWandering && !isChasing)
        {
            if(!seekSpotFired)
            {
                StartCoroutine("WanderAround");
            }
        }

        if(isChasing && !isWandering)
        {
            ChaseThePlayer();
        }

        if(isAttacking)
        {
            Attak();
        }


        anim.SetBool("isWandering", isWandering);
        anim.SetBool("isChasing", isChasing);
        anim.SetBool("isAttacking", isAttacking);
    }

    public void ChaseThePlayer()
    {
        agent.speed = 1;
        agent.destination = player.transform.position;
    }

    public void Attak()
    {
        agent.speed = 0;
    }

    public IEnumerator WanderAround()
    {
        seekSpotFired = true;
        agent.speed = 1;
        chasePoint.transform.position = RandomPointInBounds(randoChecker.GetComponent<Collider>().bounds);
        agent.destination = chasePoint.transform.position;
        print("pizza pie");
        yield return new WaitForSeconds(3);
        seekSpotFired = false;
        print("cripsy pizza pie");
    }

    private Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
