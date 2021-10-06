using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForOtherMap : MonoBehaviour
{
    public GameObject upChecker;
    public GameObject downChecker;
    public GameObject curFloorOn;
    public GameObject otherFloor;
    // Start is called before the first frame update
    void Start()
    {
        otherFloor = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        RaycastHit hitto;

        if (curFloorOn.gameObject.tag == "MapTriggerMedieval")
        {
            if (Physics.Raycast(upChecker.transform.position, upChecker.transform.TransformDirection(Vector3.up), out hitto, Mathf.Infinity) && hitto.transform.tag == "MapTriggerModern")
            {
                Debug.DrawRay(upChecker.transform.position, upChecker.transform.up * hitto.distance, Color.cyan);
                otherFloor = hitto.transform.gameObject;
                print("did omg fuk da preppps!!!!!!!!!!");
            }

        }

        if(curFloorOn.gameObject.tag == "MapTriggerModern")
        {
            if (Physics.Raycast(downChecker.transform.position, downChecker.transform.TransformDirection(Vector3.down), out hitto, Mathf.Infinity) && hitto.transform.tag == "MapTriggerMedieval")
            {
                Debug.DrawRay(downChecker.transform.position, -downChecker.transform.up * hitto.distance, Color.cyan);
                otherFloor = hitto.transform.gameObject;
                print("did omg fuk da preppps!!!!!!!!!!");
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MapTriggerMedieval")
        {
            curFloorOn = other.gameObject;
            print("On Medieval");
        }

        if(other.tag == "MapTriggerModern")
        {
            curFloorOn = other.gameObject;
            print("On Modern");
        }
    }
}
