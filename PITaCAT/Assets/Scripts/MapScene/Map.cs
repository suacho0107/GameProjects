using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public bool playerInRange;
    public GameObject mapImage;

    public GameObject popUpImage;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange)
        {
            if (mapImage.activeInHierarchy)
            {
                mapImage.SetActive(false);
            }
            else
            {
                mapImage.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerInRange = true;

            popUpImage.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerInRange = false;
            mapImage.SetActive(false);

            popUpImage.SetActive(false);
        }
    }
}
