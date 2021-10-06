using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMaps : MonoBehaviour
{

    public bool isWarping = false;
    public bool warpButtonPressed;
    public float warpTimer;
    public float timerValue;
    public float timeToWarp;
    public GameObject mapToJumpTo;
    public float warpHeight;
    public bool warpBlocked = false;
    public float warpCooldown;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        warpTimer = timerValue;
        yield return new WaitForSeconds(1f);
        mapToJumpTo = gameObject.transform.GetChild(7).GetComponent<CheckForOtherMap>().otherFloor;
    }

    // Update is called once per frame
    void Update()
    {
        if(mapToJumpTo != null)
        {
            StartCoroutine(WarpMap());

            warpButtonPressed = Input.GetButton("Warp");

            if (warpButtonPressed && !warpBlocked)
            {

                warpTimer -= Time.deltaTime;
                print("hiiiiiiiiiiiiiiiiii");

            }

        }
    }

    IEnumerator WarpMap()
    {
        Vector3 newY = new Vector3(transform.position.x, mapToJumpTo.transform.position.y, transform.position.z);
        if (warpTimer <= 0)
        {
            warpBlocked = true;
            transform.localPosition = Vector3.Lerp(transform.position, newY, Time.deltaTime * 50);
            
            print("translate should happen");
            yield return new WaitForSeconds(warpCooldown);
            warpBlocked = false;
            mapToJumpTo = gameObject.transform.GetChild(7).GetComponent<CheckForOtherMap>().otherFloor;
            warpTimer = timerValue;
            
            
        }

    }
}
