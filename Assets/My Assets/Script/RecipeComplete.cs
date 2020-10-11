using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeComplete : MonoBehaviour
{
    public Image icon;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void SetItemImage(Sprite _image)
    {
        icon.sprite = _image;
    }
}
