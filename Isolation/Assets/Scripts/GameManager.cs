using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ǥ�� ���� ��

public class GameManager : MonoBehaviour
{
    public Text moneyText;
    float moneyCount = 0;

    public void AddMoneyCount()
    {
        ++moneyCount;   // ���� ����
        moneyText.text = "Points:   " + moneyCount;
    }
}