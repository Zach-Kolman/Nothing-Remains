using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamTrackStationary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.parent.transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().LookAt = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent.transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().LookAt = null;
    }
}
