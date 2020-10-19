using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliverySlot : MonoBehaviour
{
    public Item item;//구매 아이템
    public Image icon;//아이템 아이콘

    [SerializeField]
    public int price; //가격

    [SerializeField]
    public int number;//구매갯수

    public Text numberText;
    public Text priceText;

    private void Awake()
    {
        item = null;
        //icon = GetComponentInChildren<Image>();
        
        number = 0;
        numberText.text = number.ToString();
        
    }

   

    public void SetItem(Item _item)
    {
        item = _item;
        Color color = icon.color;
        color.a = 1f;
        icon.color = color;
        icon.sprite = _item.itemImage;
        price = _item.price;
        priceText.text = price.ToString();
    }

    public void Increase()
    {
        if (number < 99)
        {
            number++;
            numberText.text = number.ToString();
        }
    }

    public void Decrease()
    {
        if (number > 0)
        {
            number--;
            numberText.text = number.ToString();
        }
        
    }

    public void ResetSlot()
    {
        number = 0;
        numberText.text = number.ToString();
    }

    public void ShowStock(Item _item)
    {
         
    }

    
}
