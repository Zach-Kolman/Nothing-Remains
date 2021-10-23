using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheDialogue : MonoBehaviour
{
    public bool isInteracting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isInteracting = Input.GetButton("Interact");

    }
    
    void StartDialogueBro()
    {
        
    }
}
