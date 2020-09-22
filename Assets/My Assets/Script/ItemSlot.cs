using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    public Image icon;
   // public Text itemName_Text;
    public Text itemCount_Text;

    //public GameObject slot;

    //public int itemCount;


    public void Additem(Item _item)
    {
        //itemName_Text.text = _item.itemName;
        icon.sprite = _item.itemImage;
        if (Item.ItemType.INGREDIENT==_item.itemType)
        {
            if (_item.itemCount > 0) itemCount_Text.text = _item.itemCount.ToString();
            else itemCount_Text.text = "0";
        }
    }

    public void RemoveItem()
    {
       // itemName_Text.text = "";
        itemCount_Text.text = "";
        icon.sprite = null;
    }
   

    
}
