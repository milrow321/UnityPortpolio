using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterSlot : MonoBehaviour
{
    public Item item;
    public Image icon;

    public void SetItem(Item _item)
    {
        item = _item;
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

}
