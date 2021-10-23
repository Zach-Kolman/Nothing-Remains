using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfShot : MonoBehaviour
{
  
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
        if(other.gameObject.tag == "Mob")
        {
            gameObject.GetComponentInParent<playerController>().inSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponentInParent<playerController>().inSight = false;
    }
}
