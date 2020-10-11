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

    private void Start()
    {
        instance = this;
        gold = 100;
        goldText.text = gold.ToString();
    }

    private void Update()
    {
        goldText.text = gold.ToString();
    }
}
