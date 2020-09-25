using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Kitchen : MonoBehaviour 
{
    static public Kitchen instance;

    private int recipeCount;

    [SerializeField]
    private List<Item> mixSlotList;

    public Dictionary<List<Item>, string> recipeBook;

    private List<Item>[] recipe;

    public MixSlot[] mixSlot;

    public Transform tf;

    private void Start()
    {
        mixSlot = tf.GetComponentsInChildren<MixSlot>();

        recipeCount = 3;

        instance = this;
        mixSlotList = new List<Item>();

        recipeBook = new Dictionary<List<Item>, string>();

        recipe = new List<Item>[3];

        recipe[0] = new List<Item>();
        recipe[0].Add(new Item(00000, "apple", "사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        recipe[0].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[0], "사과주스");

        //recipe[0].Add(new Item(00000,"apple", "사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        //recipe[0].Add(new Item(00100,"water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        //recipeBook.Add(recipe[0], "사과주스");

        recipe[1] = new List<Item>();
        recipe[1].Add(new Item(00001, "straberry", "딸기", "잘익은 빨간 딸기", Item.ItemType.INGREDIENT));
        recipe[1].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[1], "딸기주스");


        recipe[2] = new List<Item>();
        recipe[2].Add(new Item(00002, "cherry", "체리", "탱탱한 체리", Item.ItemType.INGREDIENT));
        recipe[2].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[2], "체리주스");

        //recipe.Clear();

    }

    public void AddDragSlotItem(Item _item)
    {
        mixSlotList.Add(_item);
    }

    public void Cook()
    {
        if (mixSlotList.Count > 0)
        {
            for (int i = 0; i < recipeCount; i++)
            {
                if ((from tem in mixSlotList select tem).SequenceEqual(recipe[i], new RecipeComparer()))
                {
                    mixSlotList = recipe[i];
                    if (recipeBook.TryGetValue(mixSlotList, out string res))
                    {
                        Debug.Log(res);
                        mixSlotList.Clear();
                        mixSlotList = new List<Item>();
                        for (int j = 0; j < mixSlot.Length; j++)
                        {
                            mixSlot[j].DeleteImage();
                        }
                    }
                }

            }
        }
        else return;
        


        
        
    }

    public void Erase()
    {
        mixSlotList.Clear();
        for (int i = 0; i < mixSlot.Length; i++)
        {
            mixSlot[i].DeleteImage();

        }
        
        
    }

    
}
