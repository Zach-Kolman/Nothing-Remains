using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScreen : MonoBehaviour
{
    public Transform curCam;
    private Quaternion curRot;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        curRot = transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        setCam();
        transform.rotation = curCam.rotation * curRot;
    }

    void setCam()
    {
        Camera  zaCam;
        foreach(var cam in Camera.allCameras)
        {
            zaCam = cam;
        }
    }
}
