using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorbeTitle : MonoBehaviour
{
    public Color brightness;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = brightness;
        PingPong();
    }

    void PingPong()
    {
        brightness = Color.Lerp(Color.gray, Color.white, Mathf.PingPong(Time.time, 1.4f));
    }
}
