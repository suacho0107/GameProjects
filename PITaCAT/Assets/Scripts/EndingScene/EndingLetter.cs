using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingLetter : MonoBehaviour
{
    public Text endingTxt_A;

    string dialogue;

    void Start()
    {
        dialogue = "letter A";
        StartCoroutine(Typing(dialogue));
    }



    IEnumerator Typing(string talk)
    {
        // endingTxt_A.text = null;

        // 띄어쓰기 두 번이면 줄바꿈으로 바꿔주기
        if (talk.Contains("  ")) talk = talk.Replace("  ", "\n");

        for(int i = 0; i < talk.Length; i++)
        {
            endingTxt_A.text += talk[i];
            // 속도
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.5f);
        print("\n");
    }
}
