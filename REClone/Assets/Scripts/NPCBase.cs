using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
   
    public float blend;

    Animator npcAnim;
    // Start is called before the first frame update
    void Start()
    {
        npcAnim = gameObject.GetComponent<Animator>();
        npcAnim.SetFloat("Blend", blend);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
