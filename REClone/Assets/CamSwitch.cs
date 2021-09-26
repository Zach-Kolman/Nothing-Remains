using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public Camera curCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        foreach (var cam in Camera.allCameras)
        {
            cam.enabled = false;
        }

        Camera myCam = curCam;

        myCam.enabled = true;
        Debug.Log("ey");
    }
}
