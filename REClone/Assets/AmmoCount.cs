using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public float currentAmmo;
    public float stashAmmo;
    public Text curText;
    public Text stashText;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmo = player.GetComponent<AmmoHandler>().curAmmo;
        stashAmmo = player.GetComponent<AmmoHandler>().stashAmmo;

        ToStrings();
    }

    void ToStrings()
    {
        curText.text = currentAmmo.ToString();
        stashText.text = stashAmmo.ToString();
    }
}
