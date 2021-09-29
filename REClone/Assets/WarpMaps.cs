using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMaps : MonoBehaviour
{

    public bool isWarping = false;
    public bool warpButtonPressed;
    public float warpTimer = 10;
    public float timeToWarp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        warpButtonPressed = Input.GetButton("Warp");

        if(warpButtonPressed)
        {
            if(warpTimer > 0)
            {
                warpTimer -= Time.deltaTime;
                print("hiiiiiiiiiiiiiiiiii");
            }
        }
    }
}
