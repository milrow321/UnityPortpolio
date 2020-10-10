using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CounterSlot : MonoBehaviour
{
    public Item item;
    public Image icon;

    public OrderPanel orderPanel;
    public TablePool tablePool;

    public int tableCount;
    public int chairCount;

    [SerializeField]
    List<Customer> prio;


    public void SetItem(Item _item)
    {
        item = _item;
        Color color = icon.color;
        color.a = 1f;
        icon.color = color;
        icon.sprite = _item.itemImage;
    }

    public void EraseItem()
    {
        item = null;
        
        icon.sprite = null;

        Color color = icon.color;
        color.a = 0f;
        icon.color = color;
    }

    public void IndicateServe()
    {
        prio.Clear();
        prio = new List<Customer>();
        if (item != null)
        {
            for (int i = 0; i < orderPanel.orderSlotPanels.Length; i++)
            {
                for (int j = 0; j < orderPanel.orderSlotPanels[i].slot.Length; j++)
                {
                    if (orderPanel.orderSlotPanels[i].slot[j].item == null) continue;
                    if (item.itemID == orderPanel.orderSlotPanels[i].slot[j].item.itemID)
                    {
                        if (tablePool.table[i].chair[j].onCustomer!=null&& !tablePool.table[i].chair[j].onCustomer.recieved)                     
                        {
                            var servePriority = tablePool.table[i].chair[j].onCustomer;

                            prio.Add(servePriority);
                            
                            
                        }
                            

                    }
                }
            }
            

        }

        

    }

    public Customer Serving()
    {
        if (prio.Count == 0) return null;
        prio.Sort(delegate (Customer a, Customer b)
        {
            if (a.numberTicket > b.numberTicket) return 1;
            else if (a.numberTicket == b.numberTicket) return -1;
            return 0;
        });

        Customer cus;
        cus = prio[0];
        
        
        return cus;
        
    }

}
