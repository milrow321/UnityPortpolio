using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Kitchen : MonoBehaviour 
{


    static public Kitchen instance;

    public int count;

    private int recipeCount; 

    [SerializeField]
    private List<Item> mixSlotList; //조합 슬롯 아이템 리스트

    public Dictionary<List<Item>, int> recipeBook; //레시피 딕셔너리

    private List<Item>[] recipe; //레시피 

    public MixSlot[] mixSlot; //조합 슬롯들

    public Transform mixSlotTf; //조합슬롯의 부모객체(패널)

    public CounterSlot[] counterSlot; //카운터 슬롯들
    

    public Transform counterSlotTf;

    public int CounterSlotCount;

    private void Start()
    {
        mixSlot = mixSlotTf.GetComponentsInChildren<MixSlot>();

        counterSlot = counterSlotTf.GetComponentsInChildren<CounterSlot>();
        CounterSlotCount = 0;

        count = 0;

        recipeCount = 3;

        instance = this;
        mixSlotList = new List<Item>();

        recipeBook = new Dictionary<List<Item>, int>();

        recipe = new List<Item>[3];

        recipe[0] = new List<Item>();
        recipe[0].Add(new Item(00000, "apple", "사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        recipe[0].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[0], 01000);//사과주스

        recipe[1] = new List<Item>();
        recipe[1].Add(new Item(00001, "straberry", "딸기", "잘익은 빨간 딸기", Item.ItemType.INGREDIENT));
        recipe[1].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[1], 01000);


        recipe[2] = new List<Item>();
        recipe[2].Add(new Item(00002, "cherry", "체리", "탱탱한 체리", Item.ItemType.INGREDIENT));
        recipe[2].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[2], 01000);

        

        


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
                    if (recipeBook.TryGetValue(mixSlotList, out int res))
                    {
                        ServeToCounter(res);
                        //DatabaseManager.instance.foodItemDictionary.

                        //Debug.Log(res);
                        mixSlotList.Clear();
                        mixSlotList = new List<Item>();
                        for (int j = 0; j < mixSlot.Length; j++)
                        {
                            mixSlot[j].DeleteImage();
                            count = 0;
                            RecipeReboot();


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
            count = 0;
        }
        
        
    }

    private void RecipeReboot()
    {
        recipe[0] = new List<Item>();
        recipe[0].Add(new Item(00000, "apple", "사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        recipe[0].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[0], 01000);

        recipe[1] = new List<Item>();
        recipe[1].Add(new Item(00001, "straberry", "딸기", "잘익은 빨간 딸기", Item.ItemType.INGREDIENT));
        recipe[1].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[1], 01000);


        recipe[2] = new List<Item>();
        recipe[2].Add(new Item(00002, "cherry", "체리", "탱탱한 체리", Item.ItemType.INGREDIENT));
        recipe[2].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[2], 01000);
    }

    private void ServeToCounter(int _res)
    {
        DatabaseManager.instance.foodItemDictionary.TryGetValue(_res, out Item _item);

        Color color = counterSlot[0].icon.GetComponent<Image>().color;
        color.a = 1f;

        
        if (CounterSlotCount < counterSlot.Length)
        {
            counterSlot[CounterSlotCount].icon.color = color;
            //counterSlot[CounterSlotCount].icon.sprite = _item.itemImage;

            counterSlot[CounterSlotCount].SetItem(_item);

            CounterSlotCount++;
        }
      
      

    }
}
