using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    public GameObject slot;

    public int itemCount;
    public Sprite itemImage;

    [SerializeField]
    public Item item;


    // Start is called before the first frame update
    void Start()
    {
        itemImage = item.itemImage;
    }

    
}
