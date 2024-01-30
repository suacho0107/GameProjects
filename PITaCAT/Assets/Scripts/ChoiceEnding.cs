using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceEnding : MonoBehaviour
{
    public GameObject endingPanel;
    public GameObject endingButtonA;
    public GameObject endingButtonB;

    public GameObject popUpImage;

    public bool endingInRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && endingInRange)
        {
            if (endingPanel.activeInHierarchy)
            {
                endingPanel.SetActive(false);
                endingButtonA.SetActive(false);
                endingButtonB.SetActive(false);
            }
            else
            {
                endingPanel.SetActive(true);
                endingButtonA.SetActive(true);
                endingButtonB.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            endingInRange = true;
            // dialoguePanel.SetActive(true);

            popUpImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            endingInRange = false;

            popUpImage.SetActive(false);
        }
    }
}
