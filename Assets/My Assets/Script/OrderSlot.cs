using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSlot : MonoBehaviour
{


    public Item item;
    public OrderSlotPanel slotParent;
    public Image icon;
    


    private void Start()
    {
        slotParent = transform.parent.GetComponent<OrderSlotPanel>();
    }

    public void SetCustomerOrder(Customer _cus)
    {
        item = _cus.Order();
        icon.sprite =item.itemImage;
    }



    public void SetItem(Item _item)
    {
        item = _item;
        Color color =icon.color;
        color.a = 1f;
        icon.color = color;

        icon.sprite = _item.itemImage;
        
       
    }
    public void DeleteItem()
    {
        item = null;
        icon.sprite = null;

        Color color = icon.color;
        color.a = 0f;
        icon.color = color;
        
    }
}
