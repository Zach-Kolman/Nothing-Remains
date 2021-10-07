using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{

    private GameObject player;
    public bool isFacing = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacing)
        {
            Vector3 relPos = player.transform.position - transform.position;

            Quaternion lookAtRot = Quaternion.LookRotation(relPos);

            Quaternion LookAtRotY = Quaternion.Euler(transform.eulerAngles.x, lookAtRot.eulerAngles.y, transform.eulerAngles.z);

            transform.rotation = LookAtRotY;

            Debug.DrawRay(transform.position, relPos, Color.red);
        }
    }
}
