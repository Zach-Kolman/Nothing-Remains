using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{

    public GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relPos = player.transform.position - transform.position;

        Quaternion lookAtRot = Quaternion.LookRotation(relPos);

        Quaternion LookAtRotY = Quaternion.Euler(transform.eulerAngles.x, lookAtRot.eulerAngles.y, transform.eulerAngles.z);

        transform.rotation = LookAtRotY;

        Debug.DrawRay(transform.position, relPos, Color.red);
    }
}
