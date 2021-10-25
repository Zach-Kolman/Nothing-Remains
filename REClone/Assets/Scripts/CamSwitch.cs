using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public Camera curCam;
    public GameObject enableIt;
    public AudioListener listener;
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
        if(other.tag == "Player")
        {
            //Debug.Log("hi");
            //enableIt.SetActive(true);
            foreach (var cam in Camera.allCameras)
            {
                cam.enabled = false;
            }

            Camera myCam = curCam;

            myCam.enabled = true;
            listener.transform.position = myCam.transform.position;
            //Debug.Log("ey");
        }
    }
}
