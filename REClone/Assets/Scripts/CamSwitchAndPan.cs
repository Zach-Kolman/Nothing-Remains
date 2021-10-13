using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitchAndPan : MonoBehaviour
{
    public Camera curCam;
    private Camera mamaCam;
    public bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        mamaCam = gameObject.transform.parent.transform.GetChild(0).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;

            if (inRange)
            {
                mamaCam.GetComponent<camFollowandPan>().inFollowRange = true;
                mamaCam.GetComponent<camFollowandPan>().setDist();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = false;

            if (!inRange)
            {
                mamaCam.GetComponent<camFollowandPan>().inFollowRange = false;
            }
        }
    }
}
