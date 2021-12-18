using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitch : MonoBehaviour
{
    public GameObject curCam;
    public List<GameObject> vcams;

    public int basePriority = 10;
    // Start is called before the first frame update
    void Start()
    {
        vcams = new List<GameObject>();

        foreach(GameObject veecam in GameObject.FindGameObjectsWithTag("Veecam"))
        {
            vcams.Add(veecam);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("hi");
            //enableIt.SetActive(true);
            foreach (GameObject cam in vcams)
            {
                cam.GetComponent<CinemachineVirtualCamera>().Priority = basePriority - 1;
            }

            curCam.GetComponent<CinemachineVirtualCamera>().Priority = basePriority + 1;
            //Debug.Log("ey");
        }
    }
}
