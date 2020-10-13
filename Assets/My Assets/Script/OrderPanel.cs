using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanel : MonoBehaviour
{
    static public OrderPanel instance;

    public OrderSlotPanel[] orderSlotPanels;

    

    private void Start()
    {
        this.gameObject.SetActive(false);

        instance = this;

        orderSlotPanels = GetComponentsInChildren<OrderSlotPanel>();

    }

    

}
