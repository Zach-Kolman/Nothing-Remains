using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{

    public AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().clip = bgm;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
