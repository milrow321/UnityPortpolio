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
    }

   
}
