using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cafe : MonoBehaviour
{
    public GameObject CookUI;

    // Start is called before the first frame update
    //void Start()
    //{
    //    CookUI = GetComponent<GameObject>();
    //}

   

    void OpenKitchen()
    {
        CookUI.SetActive(true);
    }

    void CloseKitchen()
    {
        CookUI.SetActive(false);
    }
}
