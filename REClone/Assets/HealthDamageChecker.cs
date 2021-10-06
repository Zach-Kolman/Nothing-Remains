using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamageChecker : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
