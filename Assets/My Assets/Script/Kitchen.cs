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

    public List<Item>[] recipe; //레시피 

    public MixSlot[] mixSlot; //조합 슬롯들

    public Transform mixSlotTf; //조합슬롯의 부모객체(패널)

    public CounterSlot[] counterSlot; //카운터 슬롯들
    

    public Transform counterSlotTf;

    public int CounterSlotCount;

    public Inventory inventory;

    private void Start()
    {
        mixSlot = mixSlotTf.GetComponentsInChildren<MixSlot>();

        counterSlot = counterSlotTf.GetComponentsInChildren<CounterSlot>();

        for (int i = 0; i < counterSlot.Length; i++)
        {
            counterSlot[i].item = null;
        }

        CounterSlotCount = 0;

        count = 0;

        recipeCount = 10;

        instance = this;
        mixSlotList = new List<Item>();

        recipeBook = new Dictionary<List<Item>, int>();

        recipe = new List<Item>[recipeCount];

        RecipeReboot();



        inventory = GetComponentInChildren<Inventory>();

        gameObject.SetActive(false);


    }

    public void AddDragSlotItem(Item _item)
    {
        mixSlotList.Add(_item);
    }

    public void Cook()
    {
        for (int i = 0; i < inventory.inventoryItemList.Count; i++)
        {
            if (inventory.inventoryItemList[i].itemCount == 0) return;
        }
       
        if (mixSlotList.Count > 0)
        {
            for (int i = 0; i < recipeCount; i++)
            {
                if (recipe[i] == null) continue;
                //Comparer를 통해 레서피 리스트와 조합 리스트를 비교
                if ((from tem in mixSlotList select tem).SequenceEqual(recipe[i], new RecipeComparer()))
                {
                    mixSlotList = recipe[i];
                    //조합 리스트를 레서피 딕셔너리에 키값으로 제공
                    if (recipeBook.TryGetValue(mixSlotList, out int res))
                    {
                        ServeToCounter(res);
                        for (int j = 0; j < mixSlotList.Count; j++)
                        {
                            inventory.RemoveFromInven(mixSlotList[j], 1);
                        }
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
        //recipe[0].Add(new Item(00000, "apple", "사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        //recipe[0].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        //recipeBook.Add(recipe[0], 01000);

        recipe[1] = new List<Item>();
        recipe[1].Add(new Item(00001, "straberry", "딸기", "잘익은 빨간 딸기", Item.ItemType.INGREDIENT));
        recipe[1].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[1], 01001);//딸기주스
        
        recipe[2] = new List<Item>();
        //recipe[2].Add(new Item(00002, "cherry", "체리", "탱탱한 체리", Item.ItemType.INGREDIENT));
        //recipe[2].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        //recipeBook.Add(recipe[2], 01000);

        recipe[3] = new List<Item>();
        recipe[3].Add(new Item(00003, "grapes", "포도", "보라빛의 포도", Item.ItemType.INGREDIENT));
        recipe[3].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[3], 01003);//포도주스

        recipe[4] = new List<Item>();


        recipe[5] = new List<Item>();
        recipe[5].Add(new Item(00005, "coffee", "커피콩", "모든 커피의 근본이 되는 재료", Item.ItemType.INGREDIENT));
        recipe[5].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[5], 01005);//다크커피

        recipe[6] = new List<Item>();
        recipe[6].Add(new Item(00005, "coffee", "커피콩", "모든 커피의 근본이 되는 재료", Item.ItemType.INGREDIENT));    
        recipe[6].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipe[6].Add(new Item(00101, "milk", "우유", "뼈가 튼튼해지는 우유", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[6], 01006);//카페라떼

        recipe[7] = new List<Item>();
        recipe[7].Add(new Item(00005, "coffee", "커피콩", "모든 커피의 근본이 되는 재료", Item.ItemType.INGREDIENT));
        recipe[7].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipe[7].Add(new Item(00101, "milk", "우유", "뼈가 튼튼해지는 우유", Item.ItemType.INGREDIENT));
        recipe[7].Add(new Item(00006, "chocolate", "초콜렛", "달콤 씁씁한 매력의 간식이자 재료", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[7], 01007);//카페모카

        recipe[8] = new List<Item>();
        recipe[8].Add(new Item(00005, "coffee", "커피콩", "모든 커피의 근본이 되는 재료", Item.ItemType.INGREDIENT));
        recipe[8].Add(new Item(00100, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        recipe[8].Add(new Item(00007, "ice cream", "아이스크림", "사계절 시원하게 즐기는 간식", Item.ItemType.INGREDIENT));
        recipeBook.Add(recipe[8], 01008);//아포카토

        



    }

    private void ServeToCounter(int _res)
    {
        DatabaseManager.instance.foodItemDictionary.TryGetValue(_res, out Item _item);

        //Color color = counterSlot[0].icon.GetComponent<Image>().color;
        //color.a = 1f;


        //if (CounterSlotCount < counterSlot.Length)
        //{
        //    //counterSlot[CounterSlotCount].icon.color = color;
        //    //counterSlot[CounterSlotCount].icon.sprite = _item.itemImage;

        //    counterSlot[CounterSlotCount].SetItem(_item);

        //    CounterSlotCount++;
        //}

        for (int i = 0; i < counterSlot.Length; i++)
        {
            if (counterSlot[i].item == null || counterSlot[i].item.itemImage == null)
            {
                counterSlot[i].SetItem(_item);
                break;  
            }
            else continue;
        }
      

    }
}
