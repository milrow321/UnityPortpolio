using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSlot : MonoBehaviour
{


    public Item item;
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



    public void SetItem(Item _item, Customer _customer)
    {
        item = _item;
        Color color =icon.color;
        color.a = 1f;
        icon.color = color;

        icon.sprite = _item.itemImage;

        customer = _customer;  
    }


    public void DeleteItem()
    {
        item = null;
        icon.sprite = null;

        Color color = icon.color;
        color.a = 0f;
        icon.color = color;
        customer = null;
    }
}
