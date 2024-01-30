using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Image;
    public Text P_talk;
    public string [] disalogtalk;
    public string[] dialofues;
    public int talkNum;
    public GameObject clicktext;

    public void starttalk(string[] talks) {
        dialofues = talks;

        StartCoroutine(Typing(dialofues[talkNum]));
    }

    public void NextTalk() {
        P_talk.text = null;
        talkNum++;

        if (talkNum == dialofues.Length) {
            EndTalk();
            return;
        }
        StartCoroutine(Typing(dialofues[talkNum]));
    }
    public void EndTalk() {
        talkNum= 0;
        
        clicktext.SetActive(true);
    }

    //게임 화면으로 넘어가기
    public void StButton()
    {
        SceneManager.LoadScene("WebtoonScene");
    }

    ////게임 창 닫기
    //public void ExitButton()
    //{
    //    GameQuit();
    //}
    //public void GameQuit()
    //{
    //    //unity editor에서
    //    UnityEditor.EditorApplication.isPlaying = false;
    //    //응용 프로그램,모바일에서
    //    Application.Quit();
    //}
    public int click = 0;
    public bool isClicked;

    //웹툰 클릭 
    public void nextstage1()
    {
        isClicked = !isClicked;
        if (isClicked)
        {
            if (click == 0)
            {
                Image[0].SetActive(false);
                Image[1].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 1)
            {
                Image[2].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 2)
            {
                Image[1].SetActive(false);
                Image[2].SetActive(false);
                Image[3].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 3)
            {
                Image[4].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 4)
            {
                Image[5].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 5)
            {
                Image[3].SetActive(false);
                Image[4].SetActive(false);
                Image[5].SetActive(false);
                Image[6].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 6)
            {
                Image[7].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 7)
            {
                Image[8].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 8)
            {
                Image[6].SetActive(false);
                Image[7].SetActive(false);
                Image[8].SetActive(false);
                Image[9].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 9)
            {
                Image[10].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 10)
            {
                Image[11].SetActive(true);
                click++;
                isClicked = !isClicked;
            }
            else if (click == 11)
            {
                Image[9].SetActive(false);
                Image[10].SetActive(false);
                Image[11].SetActive(false);
                Image[12].SetActive(true);
                starttalk(disalogtalk);
                click++;
                isClicked = !isClicked;
            }
            
            else if (click == 12)
            {
                //게임 씬으로 이동
                SceneManager.LoadScene("MapScene");
            }
        }

    }  
    IEnumerator Typing(string talk){
        P_talk.text = null;
        if (talk.Contains("  ")) {
            talk = talk.Replace("  ", "\n");
        }

        for (int i = 0; i < talk.Length; i++) {
            P_talk.text += talk[i];
            yield return new WaitForSeconds(0.08f);
        }

        yield return new WaitForSeconds(1.5f);
        NextTalk();
    }
}
