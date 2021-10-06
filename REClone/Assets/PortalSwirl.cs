using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSwirl : MonoBehaviour
{
    public float swirlDir;
    Animator Anim;
    public bool isFlipped;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("IsFlipped", isFlipped);
        Anim.SetFloat("Swirl", swirlDir);
    }
}
