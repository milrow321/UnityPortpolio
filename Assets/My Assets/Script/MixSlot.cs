﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MixSlot : MonoBehaviour
{


    

    public Image icon;
    private RectTransform parent;

    private void Start()
    {
        parent = transform.parent.GetComponent<RectTransform>();
    }

    public void MixSetImage(Image _itemImage)
    {
        icon.sprite = _itemImage.sprite;
    }
   public void DeleteImage()
    {
        Color color = icon.color;
        color.a = 0f;
        icon.color = color;
        icon.sprite = null;

    }

    
}
