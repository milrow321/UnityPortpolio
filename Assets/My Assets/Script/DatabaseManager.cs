using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    static public DatabaseManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        itemList.Add(new Item("apple","사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        itemList.Add(new Item("straberry", "딸기", "잘익은 빨간 딸기", Item.ItemType.INGREDIENT));
        itemList.Add(new Item("cherry","체리", "탱탱한 체리", Item.ItemType.INGREDIENT));
        itemList.Add(new Item("grapes", "포도", "보라빛의 포도", Item.ItemType.INGREDIENT));
        itemList.Add(new Item("water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        itemList.Add(new Item("milk", "우유", "뼈가 튼튼해지는 우유", Item.ItemType.INGREDIENT));

        itemList.Add(new Item("w_047", "바람의 대검", "바람의 기운을 담은 대검", Item.ItemType.EQUIPMENT));
    }

   
}
