using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image icon;
   // public Text itemName_Text;
    public Text itemCount_Text;

    public ItemSlot[] ingredient;

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragSlot.instance.dragSlot = this;
        DragSlot.instance.DragSetImage(icon);
        DragSlot.instance.SetColor(1);
        DragSlot.instance.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragSlot.instance.transform.position = eventData.position;

    }

    public void OnDrop(PointerEventData eventData)
    {
        for (int i = 0; i < ingredient.Length; i++)
        {
           
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
    }

    public void RemoveItem()
    {
       // itemName_Text.text = "";
        itemCount_Text.text = "";
        icon.sprite = null;
    }
   

    
}
