using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollowandPan : MonoBehaviour
{
    private Transform player;

    private Transform offsetPos;

    public Vector3 moveAxis;

    public float offset;

    public bool inFollowRange = false;

    private Vector3 direction;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        offsetPos = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - offsetPos.transform.position;

        position = player.transform.position + direction;
        CamFollow();
        camPan();
    }

    void CamFollow()
    {

        if (!inFollowRange)
        {
            transform.LookAt(player);
          
        }

    }

    void camPan()
    {
        if (inFollowRange)
        {


            transform.position = position;
            Debug.Log("hey");
        }

        else
        {
            transform.LookAt(player);
        }
    }

}