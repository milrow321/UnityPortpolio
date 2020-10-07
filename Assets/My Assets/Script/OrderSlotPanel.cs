using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSlotPanel : MonoBehaviour
{
    
    public OrderSlot[] slot;

    private void Awake()
    {
       slot = GetComponentsInChildren<OrderSlot>();
    }

}
