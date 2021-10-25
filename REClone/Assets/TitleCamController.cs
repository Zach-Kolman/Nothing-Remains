using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleCamController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitPlay()
    {
        animator.SetBool("PlayWasHit", true);
        animator.SetBool("BackWasHit", false);
    }

    public void ReturnTOExit()
    {
        animator.SetBool("PlayWasHit", false);
        animator.SetBool("BackWasHit", true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
