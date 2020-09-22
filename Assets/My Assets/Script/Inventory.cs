using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    //public static bool invetoryActivate = false;

    //[SerializeField]
    //private GameObject go_InventoryBase;

    //[SerializeField]
    //private GameObject go_SlotsParent;


    private ItemSlot[] slots; //인벤토리 슬롯들

    private List<Item> inventoryItemList; // 플레이어가 소지중인 아이템 리스트
    private List<Item> inventoryTabList; //선택한 카테고리에 따른 아이템 이스트

    public Text Description_Text; //부연 설명
    public string[] tabDescription; //탭 부연 설명

    public Transform tf; //slot 부모 객체

    //public GameObject go; //인벤토리 활성화 비활성화
    public GameObject[] selectedTabImage;

    private int selectedItem; //선택된 아이템
    private int selectedTab; //선택됨 탭

    private bool activated; //인벤토리 활성화시 true
    private bool tabActivated; //탭 활성화시 true
    private bool itemActivated;
    private bool stopKeyInput; //키입력 제한
    private bool preventExec; //중복실행 제한

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Start is called before the first frame update
    void Start()
    {
        inventoryItemList = new List<Item>();
        inventoryTabList = new List<Item>();

        slots = tf.GetComponentsInChildren<ItemSlot>();

        inventoryItemList.Add(new Item("apple", "사과", "잘익은 빨간 사과", Item.ItemType.INGREDIENT));
        inventoryItemList.Add(new Item("straberry", "딸기", "잘익은 빨간 딸기", Item.ItemType.INGREDIENT));
        inventoryItemList.Add(new Item("cherry", "체리", "탱탱한 체리", Item.ItemType.INGREDIENT));
        inventoryItemList.Add(new Item("grapes", "포도", "보라빛의 포도", Item.ItemType.INGREDIENT));

        Color color = slots[0].icon.GetComponent<Image>().color;
        color.a = 1f;

        for (int i = 0; i<inventoryItemList.Count; i++)
        {
            
            slots[i].icon.GetComponent<Image>().color = color;
            slots[i].Additem(inventoryItemList[i]);
            
        }
        

    }

    public void SelectTab(int _selectTab)
    {
        selectedTab = _selectTab;
        
            
            
            
         

    }

    


public void ShowItem()
    {
        inventoryTabList.Clear();
        
        selectedItem = 0;

        switch (selectedTab)
        {
            case 0:
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.INGREDIENT == inventoryItemList[i].itemType)
                    {
                        inventoryTabList.Add(inventoryTabList[i]);
                        
                    }
                }
                break;
            case 1:
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.EQUIPMENT == inventoryItemList[i].itemType)
                    {
                        inventoryTabList.Add(inventoryTabList[i]);
                        
                    }
                }
                break;
            case 2:
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.USE == inventoryItemList[i].itemType)
                    {
                        inventoryTabList.Add(inventoryTabList[i]);
                        
                    }
                }
                break;
        }

       
    }

    

    

    // Update is called once per frame
    void Update()
    {
        


    }

   
   
}
