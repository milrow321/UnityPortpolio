using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    

    public Image icon;
   // public Text itemName_Text;
    public Text itemCount_Text;

    //public GameObject slot;

    //public int itemCount;


    



    private Item item;

   
    public void Additem(Item _item)
    {
        item = _item;
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

   

    public void OnBeginDrag(PointerEventData eventData)
    {

        

        DragSlot.instance.dragSlot = this;
        DragSlot.instance.dragSlot.item = item;
        DragSlot.instance.DragSetImage(icon);
        DragSlot.instance.SetColor(1);
        DragSlot.instance.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragSlot.instance.transform.position = eventData.position;

    }

    //public void OnDrop(PointerEventData eventData)
    //{
    //    MixSlot.instance.mixSlot = DragSlot.instance.dragSlot;
    //    MixSlot.instance.MixSetImage(DragSlot.instance.dragSlot.icon);
    //    //MixSlot.instance.addSlotList();
    //}

    public void OnEndDrag(PointerEventData eventData)
    {



        
        if (Kitchen.instance.count < Kitchen.instance.mixSlot.Length)
        {
            Kitchen.instance.AddDragSlotItem(DragSlot.instance.dragSlot.item);
            Color color = Kitchen.instance.mixSlot[Kitchen.instance.count].icon.color;
            color.a = 1f;
            Kitchen.instance.mixSlot[Kitchen.instance.count].icon.color = color;
            Kitchen.instance.mixSlot[Kitchen.instance.count].MixSetImage(icon);
            Kitchen.instance.count++;
        }
        else
        {
            DragSlot.instance.SetColor(0);
            DragSlot.instance.dragSlot = null;
            return;
        }



        //MixSlot.instance.mixSlot = DragSlot.instance.dragSlot;
        //MixSlot.instance.MixSetImage(DragSlot.instance.dragSlot.icon);

        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    
}
