using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSlot : MonoBehaviour
{
    

    

    public Image icon;

    

    public void SetImage(Image _itemImage)
    {
        
       

        icon.sprite = _itemImage.sprite;
        
       
    }
    public void DeleteImage()
    {
        icon.sprite = null;
    }
}
