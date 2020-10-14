using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CafeManager : MonoBehaviour
{
    static public CafeManager instance;

    FurnitureManager FurnitureMg;
    CustomerManager customerMg;

    public int gold;//소지금
    public Text goldText;
    public int reputation;//평판
    public float dayTime;
    public GameObject resultUI;


    private void Start()
    {

        instance = this;
        gold = 100;
        goldText.text = gold.ToString();
    }

    private void Update()
    {
        //dayTime += Time.deltaTime;
        //if (dayTime > 600f)
        //{
        //    Time.timeScale = 0;
        //    resultUI.SetActive(true);
        //    dayTime = 0;
        //}
        goldText.text = gold.ToString();
    }
}
