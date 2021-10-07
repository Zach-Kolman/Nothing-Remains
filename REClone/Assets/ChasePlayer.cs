using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    private GameObject player;
    NavMeshAgent agent;
    public GameObject randoChecker;
    public GameObject tawkeeky;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        WanderAround();
    }

    public void ChaseThePlayer()
    {
        agent.destination = player.transform.position;
    }

    public void WanderAround()
    {
        tawkeeky.transform.position = RandomPointInBounds(randoChecker.GetComponent<Collider>().bounds);
    }

    private Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.y, bounds.max.y)
        );
    }
}
