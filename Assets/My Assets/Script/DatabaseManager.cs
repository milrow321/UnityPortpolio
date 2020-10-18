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
    public Dictionary<int, Item> foodItemDictionary = new Dictionary<int, Item>();


    // Start is called before the first frame update
    void Start()
    {
        itemList.Add(new Item(00000,"apple","사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        itemList.Add(new Item(00001,"straberry", "딸기", "잘익은 빨간 딸기", Item.ItemType.INGREDIENT));
        itemList.Add(new Item(00002,"cherry","체리", "탱탱한 체리", Item.ItemType.INGREDIENT));
        itemList.Add(new Item(00003,"grapes", "포도", "보라빛의 포도", Item.ItemType.INGREDIENT));

        itemList.Add(new Item(00005, "coffee", "커피콩", "모든 커피의 근본이 되는 재료", Item.ItemType.INGREDIENT));
        itemList.Add(new Item(00006, "chocolate", "초콜렛", "달콤 씁씁한 매력의 간식이자 재료", Item.ItemType.INGREDIENT));
        itemList.Add(new Item(00007, "ice cream", "아이스크림", "사계절 시원하게 즐기는 간식", Item.ItemType.INGREDIENT));

        itemList.Add(new Item(00100,"water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        itemList.Add(new Item(00101,"milk", "우유", "뼈가 튼튼해지는 우유", Item.ItemType.INGREDIENT));


        //foodItemDictionary.Add(01000, new Item(01000, "vine", "사과주스", "주스입니다", Item.ItemType.FOOD));


        foodItemDictionary.Add(01001, new Item(01001,20, "Coffee_128_52", "딸기주스", "딸기를 갈아 만든 주스", Item.ItemType.FOOD));
        foodItemDictionary.Add(01003, new Item(01003,24, "Coffee_128_44", "포도주스","포도를 갈아 만든 주스", Item.ItemType.FOOD));
        foodItemDictionary.Add(01005,new Item(01005,30, "Coffee_128_01","다크커피","가장 베이직한 커피", Item.ItemType.FOOD));
        foodItemDictionary.Add(01006,new Item(01006,35,"Coffee_128_05","카페라떼","부드러운 우유를 넣은 커피",Item.ItemType.FOOD));
        foodItemDictionary.Add(01007, new Item(01007,40, "Coffee_128_04", "카페모카", "달콤한 초코와 우유를 넣은 커피", Item.ItemType.FOOD));
        foodItemDictionary.Add(01008, new Item(01008,38, "Coffee_128_02", "아포카토", "커피에 아이스크림을 넣어 탄생한 커피", Item.ItemType.FOOD));
        

        //itemList.Add(new Item(01000, "vine", "사과주스", "주스입니다", Item.ItemType.FOOD));

        itemList.Add(new Item(10003,"w_047", "바람의 대검", "바람의 기운을 담은 대검", Item.ItemType.EQUIPMENT));
    }

    
   
}
