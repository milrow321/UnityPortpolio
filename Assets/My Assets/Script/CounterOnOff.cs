using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterOnOff : MonoBehaviour
{
    public GameObject counterPanel;
    private bool counterOn;

    public Image closeArr;
    public Image openArr;




    public void ButtonSwap()
    {
        if (counterPanel.activeSelf)
        {
            counterPanel.SetActive(false);
            closeArr.gameObject.SetActive(false);
            openArr.gameObject.SetActive(true);
        }

        else
        {
            counterPanel.SetActive(true);
            closeArr.gameObject.SetActive(true);
            openArr.gameObject.SetActive(false);
        }
    }
}
