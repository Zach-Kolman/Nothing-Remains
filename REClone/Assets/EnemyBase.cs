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

    public float poseSpeed;

    private Animator anim;

    private NavMeshAgent agent;

    private Vector3 prevAgentPos;

    public float parentSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        curHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        poseSpeed = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        takeDamage();
        die();

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

    void die()
    {
        if(curHealth <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
       
    }
}
