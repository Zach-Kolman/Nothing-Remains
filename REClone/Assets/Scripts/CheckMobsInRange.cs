using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMobsInRange : MonoBehaviour
{

    public List<Collider> mobsInRange;

    public List<Collider> GetColliders()
    {
        return mobsInRange;
    }
    // Start is called before the first frame update
    void Start()
    {
        mobsInRange = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!mobsInRange.Contains(other) && other.tag == "Mob")
        {
            mobsInRange.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (mobsInRange.Contains(other) && other.tag == "Mob")
        {
            mobsInRange.Remove(other);
        }
    }
}
