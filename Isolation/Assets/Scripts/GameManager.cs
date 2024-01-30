using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 점수 표시 쓰는 중

public class GameManager : MonoBehaviour
{
    public Text moneyText;
    float moneyCount = 0;

    public void AddMoneyCount()
    {
        ++moneyCount;   // 개수 증가
        moneyText.text = "Points:   " + moneyCount;
    }
}