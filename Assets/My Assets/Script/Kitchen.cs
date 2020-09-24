using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    static public Kitchen instance;

    [SerializeField]
    private List<Item> mixSlotList;

    private void Start()
    {
        instance = this;
        mixSlotList = new List<Item>();
    }

    public void AddDragSlotItem(Item _item)
    {
        mixSlotList.Add(_item);
    }

    private void Cook()
    {
        
    }

    private void Erase()
    {
    }
}
