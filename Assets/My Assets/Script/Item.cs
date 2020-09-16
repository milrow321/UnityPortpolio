using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Item", menuName= "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;

    public string weaponType;

    public enum ItemType
    {
        DISH, //식기류
        INGREDIENT, //음식 재료
        SEASONING, //설탕 등의 조미료
        COOKER, //요리 기구
        FURNITURE,//가게 내의 가구 아이템
        INTERIAL, //인테리어 아이템(벽지, 바닥)
        SPECIAL, //특별 아이템(퀘스트 아이템 등)
        ECT
    }



}
