using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFlashlight : MonoBehaviour
{
    public bool lightToggled = false;
    public bool lightOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightToggled = Input.GetButtonDown("Flashlight");
        LightToggle();
    }

    void LightToggle()
    {
        
       

        if(lightOn)
        {
            gameObject.GetComponent<Light>().intensity = 80;
        }
        else
        {
            gameObject.GetComponent<Light>().intensity = 0;
        }

        if (lightToggled)
        {
            lightOn = !lightOn;
        }
    }
}
