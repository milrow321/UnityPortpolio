using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour
{
    static public DragSlot instance;

    public ItemSlot dragSlot;

   

    [SerializeField]
    public Image imageItem;

    [SerializeField]
    private Item item;

    

    private void Start()
    {
        instance = this;
        
    }

    public void DragSetImage(Image _itemImage)
    {
        imageItem.sprite = _itemImage.sprite;
    }

    public void SetColor(float _alpha)
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }

    public void SetScale(float _scale)
    {
  
    }

    

}
