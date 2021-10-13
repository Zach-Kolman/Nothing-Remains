using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollowandPan : MonoBehaviour
{
    private Transform player;

    public GameObject playerRef;

    private Transform offsetPos;

    public Vector3 moveAxis;

    public float offset;

    public bool inFollowRange = false;

    private Vector3 direction;

    private Vector3 position;

    public bool doesFollow;

    // Start is called before the first frame update
    void Start()
    {
        player = playerRef.transform;
        offsetPos = gameObject.transform;
        doesFollow = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        offsetPos = gameObject.transform;
        camPan();
    }

    private void FixedUpdate()
    {
        if(doesFollow)
        {
            CamFollow();
        }

        camPan();
        //Debug.Log(direction);
    }

    void CamFollow()
    {
        if (!inFollowRange)
        {
            transform.LookAt(player);
        }
    }

    public void camPan()
    {
        
        if(inFollowRange)
        {
            position = player.position - direction;
            transform.position = position;
        }
    }

    public void setDist()
    {
        direction = player.position - offsetPos.position;
    }

}