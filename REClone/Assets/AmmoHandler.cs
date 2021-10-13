using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour
{
    public float maxAmmo;
    public float curAmmo;
    public float stashAmmo;
    // Start is called before the first frame update
    void Start()
    {
        curAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(stashAmmo < 0)
        {
            stashAmmo = 0;
        }
    }

    public void Reload()
    {
        if(stashAmmo > 0)
        {
            float curUsed = maxAmmo - curAmmo;
            
                stashAmmo -= curUsed;
                curAmmo += curUsed;
            

        }
    }
}
