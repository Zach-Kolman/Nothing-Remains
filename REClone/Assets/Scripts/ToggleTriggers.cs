using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTriggers : MonoBehaviour
{

    public GameObject[] triggers;
    public bool debugInactive = true;
    public bool debugActive = false;
    public bool trigsDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        AddTriggers();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (debugInactive && Input.GetKey(KeyCode.C))
        {
            foreach(GameObject obj in triggers)
            {
                obj.GetComponent<Renderer>().enabled = false;
                debugInactive = false;
                debugActive = true;
               
            }
        }

        if(debugActive && Input.GetKey(KeyCode.V))
        {
            foreach(GameObject obj in triggers)
            {
                obj.GetComponent<Renderer>().enabled = true;
                debugInactive = true;
                debugActive = false;
            }
        }

    }

    void AddTriggers()
    {
        triggers = GameObject.FindGameObjectsWithTag("debug");
    }
}
