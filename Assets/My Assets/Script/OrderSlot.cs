using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSlot : MonoBehaviour
{



    public OrderSlotPanel slotParent;
    public Image icon;
    private Customer customer;


    private void Start()
    {
        slotParent = transform.parent.GetComponent<OrderSlotPanel>();
    }

    public void SetCustomerOrder(Customer _cus)
    {

    }



    public void SetItem(Item _item)
    {
        Color color =icon.color;
        color.a = 1f;
        icon.color = color;

        icon.sprite = _item.itemImage;
        
       
    }
    public void DeleteImage()
    {
        icon.sprite = null;
    }
}
