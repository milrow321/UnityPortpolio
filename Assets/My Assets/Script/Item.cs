using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{

    public int itemID;
    public string itemImageName;
    public string itemName;
    public string itemDescription;
    public int itemCount;
    public Sprite itemImage;
    public int price;

    public ItemType itemType;
    
    public GameObject itemPrefab;
    public int grade;
    

    public string weaponType;

    public enum ItemType
    {
        DISH, //식기류
        INGREDIENT, //음식 재료
        SEASONING, //설탕 등의 조미료
        FOOD,//요리
        COOKER, //요리 기구
        FURNITURE,//가게 내의 가구 아이템
        EQUIPMENT,//장비류
        USE,//소모품
        SPECIAL, //특별 아이템(퀘스트 아이템 등)
        ECT
    }

    public Item(int _itemID, string _itemImageName, string _itemName, string _itemDes, ItemType _itemType, int _itemCount=1)
    {
        itemID = _itemID;
        itemImageName = _itemImageName;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
        itemImage = Resources.Load("Food icons Pack/PNG/"+_itemImageName, typeof(Sprite))as Sprite;
    }

    public Item(int _itemID, int _price, string _itemImageName, string _itemName, string _itemDes, ItemType _itemType, int _itemCount = 1)
    {
        itemID = _itemID;
        price = _price;
        itemImageName = _itemImageName;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
        itemImage = Resources.Load("Food icons Pack/PNG/" + _itemImageName, typeof(Sprite)) as Sprite;
        
    }
}
