using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    static public Kitchen instance;

    [SerializeField]
    private List<Item> mixSlotList;

    public Dictionary<List<Item>, string> recipeBook;

    private List<Item> recipe;

    private void Start()
    {
        instance = this;
        mixSlotList = new List<Item>();

        recipeBook = new Dictionary<List<Item>, string>();
        recipe = new List<Item>();

        recipe.Add(new Item("apple", "사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        recipe.Add(new Item("water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe, "사과주스");
        recipe.Clear();
        
    }

    public void AddDragSlotItem(Item _item)
    {
        mixSlotList.Add(_item);
    }

    public void Cook()
    {
        string rec;
        if (recipeBook.TryGetValue(mixSlotList, out rec))
        {
            Debug.Log(rec);
        }
        
    }

    public void Erase()
    {
        mixSlotList.Clear();
    }
}
