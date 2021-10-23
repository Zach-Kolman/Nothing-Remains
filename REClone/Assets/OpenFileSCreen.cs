using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFileSCreen : MonoBehaviour
{
    public GameObject fileScreen;
    bool screenIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheScreen()
    {
        if(screenIsOpen)
        {
            fileScreen.GetComponent<Animator>().SetBool("isOpen", false);
            screenIsOpen = false;
        }

        else
        {
            fileScreen.GetComponent<Animator>().SetBool("isOpen", true);
            screenIsOpen = true;
        }
    }
}
