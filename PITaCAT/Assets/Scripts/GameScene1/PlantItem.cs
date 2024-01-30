using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject  plant;   // Scriptable Object

    public Text         nameTxt;
    public Text         priceTxt;
    public Image        icon;

    public Image        btnImage;
    public Text         btnTxt;

    FarmManager         fm;

    void Start()
    {
        fm = FindObjectOfType<FarmManager>();

        InitializeUI();
    }

    public void BuyPlant()
    {
        // Debug.Log("구입품목: " + plant.plantName);
        fm.SelectedPlant(this);     // this = PlantItem script
    }

    void InitializeUI()
    {
        // PlantObject의 변수 plant와 일치시키기
        nameTxt.text = plant.plantName;
        priceTxt.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }
}
