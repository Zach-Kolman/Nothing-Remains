using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    public bool inRange = false;
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        player.transform.GetChild(10).gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        player.transform.GetChild(10).gameObject.SetActive(false);
        FindObjectOfType<DialogueManager>().EndDialogue();
    }

    private void Update()
    {
        if (player.GetComponent<StartTheDialogue>().isInteracting == true && inRange)
        {
            print("startingDialogue");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
