﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool invetoryActivate = false;

    [SerializeField]
    private GameObject go_InventoryBase;

    [SerializeField]
    private GameObject go_SlotsParent;


    private Slot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentInChildren<Slot[]>();
    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
            
    }
    private void TryOpenInventory()
    {
        invetoryActivate = !invetoryActivate;

        if (invetoryActivate) OnenInventory();
        else CloseInventory();
    }

    private void OnenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);  
    }

    public void AcquireItem(Item _item, int _count)
    {
        if(Item.ItemType.COOKER!=_item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item.itemName == _item.itemName)
                {
                    slots[i].SetSlotCount(_count);
                    return;
                }
            }
        }

        

        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item.itemName == "")
            {
                slots[i].AddItem(_item,_count);
                return;
            }
        }
    }
}