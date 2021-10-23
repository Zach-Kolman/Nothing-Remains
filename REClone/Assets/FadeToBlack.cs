using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    public Color trans;
    float t = 0;
    bool isChanging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().color = trans;
        t += Time.deltaTime;
        if(isChanging)
        {
            trans = Color.Lerp(Color.clear, Color.black, Time.deltaTime);
        }
    }

    public IEnumerator FadeOut()
    {
        isChanging = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Modern_Facility");
    }

    public void DoFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}
