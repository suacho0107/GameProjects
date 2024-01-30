using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    FishingMiniGame restart;
    PlayerMove rot;
    public GameObject fishingMinigame;
    public GameObject Explain;
    public GameObject restartbutton;
    public GameObject endtbutton;

    void Start()
    {
        restart = GameObject.Find("fishingMiniGame").GetComponent<FishingMiniGame>();
        rot= GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    public void fStartButtonDown()   //시작버튼
    {
        
        Explain.SetActive(false);
        fishingMinigame.SetActive(true);
        
        restart.Restart();

    }

    public void fRestartButtonDown()   //재시작버튼
    {
        restartbutton.SetActive(false);
        endtbutton.SetActive(false);
        restart.Restart();
        Debug.Log("재시작버튼 눌림");
    }

    public void fEndButtonDown()   //끝내기 버튼
    {
        fishingMinigame.SetActive(false);
        rot.fishrod.SetActive(false);
        restartbutton.SetActive(false);
        endtbutton.SetActive(false);
        
        Debug.Log("끝내기 버튼 눌림");
    }
}
