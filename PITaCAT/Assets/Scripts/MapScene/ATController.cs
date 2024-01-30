using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATController : MonoBehaviour
{
    public GameObject areaTransitionsNS;
    public bool playerInRange2;

    void Update()
    {
        if (playerInRange2)
        {
            if (areaTransitionsNS.activeInHierarchy)
            {
                areaTransitionsNS.SetActive(false);
            }
            else
            {
                areaTransitionsNS.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
            playerInRange2 = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerInRange2 = false;
            areaTransitionsNS.SetActive(false);
        }
    }
}
