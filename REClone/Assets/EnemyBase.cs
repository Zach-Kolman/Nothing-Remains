using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;

    public bool gotShot = false;

    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        curHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        takeDamage();
        die();
    }

    public void takeDamage()
    {
        if(gotShot)
        {
            print("ow");
            curHealth = curHealth - 8;
            gotShot = false;
        }
    }

    void die()
    {
        if(curHealth <= 0)
        {
            gameObject.SetActive(false);
            player.GetComponent<playerController>().mobs.Remove(gameObject.GetComponent<playerController>().GetClosestEnemy().gameObject.GetComponent<Collider>());
        }
       
    }
}
