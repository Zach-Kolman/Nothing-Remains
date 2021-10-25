using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePods : MonoBehaviour
{
    public Animator aniamtor;
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
        aniamtor.SetBool("PodMove", true);
    }
}
