using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

   public void StartDialogue(Dialogue dial)
    {
        animator.SetBool("isOpen", true);

        Debug.Log("starting convo with: " + dial.name);

        nameText.text = dial.name;

        sentences.Clear();

        foreach(string sent in dial.sentences)
        {
            sentences.Enqueue(sent);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        print(sentences.Count.ToString());
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string theSent = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(theSent));
    }

    IEnumerator TypeSentence(string sentenceType)
    {
        dialogueText.text = "";
        foreach(char letter in sentenceType.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of Convo");
    }
}
