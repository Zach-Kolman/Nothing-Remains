using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{

    Quaternion LookAtRotY;

    public float stepCount = 90f;

    Transform closestMob;
    // Start is called before the first frame update
    void Start()
    {
        closestMob = gameObject.GetComponent<playerController>().GetClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        closestMob = gameObject.GetComponent<playerController>().GetClosestEnemy();
        if (closestMob != null)
        {
            closestMob = gameObject.GetComponent<playerController>().GetClosestEnemy();

            Vector3 relPos = closestMob.position - transform.position;

            Quaternion lookAtRot = Quaternion.LookRotation(relPos);

            LookAtRotY = Quaternion.Euler(transform.eulerAngles.x, lookAtRot.eulerAngles.y, transform.eulerAngles.z);

            Debug.DrawRay(transform.position, relPos, Color.green);
        }
    }

    public void lookAtMob()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotY, stepCount);
    }
}
