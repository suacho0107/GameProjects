using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearNPC : MonoBehaviour
{
    public GameObject clearDialoguePanel;
    public Text clearText;
    public string[] clearDialogue;
    private int index2;

    public GameObject contButton2;
    public float wordSpeed2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (clearDialoguePanel.activeInHierarchy)
            {
                zeroText2();
            }
            else
            {
                clearDialoguePanel.SetActive(true);
                StartCoroutine(Typing2());
            }
        }

        if (clearText.text == clearDialogue[index2])
        {
            contButton2.SetActive(true);
        }
    }

    public void zeroText2()
    {
        clearText.text = "";
        index2 = 0;
        clearDialoguePanel.SetActive(false);
    }

    IEnumerator Typing2()
    {
        foreach(char letter2 in clearDialogue[index2].ToCharArray())
        {
            clearText.text += letter2;
            yield return new WaitForSeconds(wordSpeed2);
        }
    }

    public void NextLine2()
    {
        contButton2.SetActive(false);

        if (index2 < clearDialogue.Length - 1)
        {
            index2++;
            clearText.text = "";
            StartCoroutine(Typing2());
        }
        else
        {
            zeroText2();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // playerIsClose = true; // No need for this line
            // dialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // playerIsClose = false; // No need for this line
            zeroText2();
        }
    }
}
