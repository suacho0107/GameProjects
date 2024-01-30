using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FarmManager : MonoBehaviour
{
    // PlantItem의 ScriptableObject 상속(Reference)
    public PlantItem    selectPlant;
    public bool         isPlanting = false;
    public int          money = 100;
    public Text         moneyTxt;

    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    public bool isSelecting = false;
    public int selectedTool = 0;
    // 1- water 2- fertilizer 3- Buy Plot

    public Image[] buttonsImg;
    public Sprite normalButton;
    public Sprite selectedButton;

    // clear panel
    public GameObject clearPanel;

    void Start()
    {
        moneyTxt.text = "$" + money;
    }

    void Update()
    {
        if (money >= 1000)
        {
            clearPanel.SetActive(true);
        }
    }


    public void SelectedPlant(PlantItem newPlant)   // BuyPlant() 함수에서 호출
    {
        if (selectPlant == newPlant)    // deselected
        {
            CheckSelection();
        }
        else                            // select another plant
        {
            CheckSelection();
            selectPlant = newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnTxt.text = "취소";
            isPlanting = true;
        }
    }

    public void SelectTool(int toolNumber)
    {
        if (toolNumber == selectedTool)
        {
            // deselected
            CheckSelection();
        }
        else
        {
            // select tool number and check to see if anything was also selected
            CheckSelection();
            isSelecting = true;
            selectedTool = toolNumber;
            buttonsImg[toolNumber - 1].sprite = selectedButton; // buttonImg: 0~2, toolNumber: 1~3
        }
    }

    void CheckSelection()   // check for anyting is already selected
    {
        if (isPlanting)
        {
            isPlanting = false;
            if (selectPlant != null)    // plant already selected
            {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnTxt.text = "구입";
                selectPlant = null;
            }
        }
        if (isSelecting)
        {
            if (selectedTool > 0)
            {
                buttonsImg[selectedTool - 1].sprite = normalButton;
            }
            isSelecting = false;
            selectedTool = 0;
        }
    }

    public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = "$" + money;
    }
}