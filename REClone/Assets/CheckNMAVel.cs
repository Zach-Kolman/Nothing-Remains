using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckNMAVel : MonoBehaviour
{

    private NavMeshAgent agent;

    public float velly;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckNMASpeed();
    }

    void CheckNMASpeed()
    {
        velly = agent.velocity.magnitude / agent.speed;
    }
}
