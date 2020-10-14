using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grocery : MonoBehaviour
{
    public Inventory inventory;
    public Transform slotParent;//아이템슬롯 부모tf
    
    public GameObject confirmPanel;

    public GameObject slotPref;
    private DeliverySlot[] deliverySlot;

    [SerializeField]
    private int tatal;

    private List<Item> productList;// 판매리스트
    private Item item;
    int purchaseNum;//구매할 갯수
    public Text confirmText;

    void Start()
    {
        productList = new List<Item>();
        productList.Add(new Item(00001,10, "straberry", "딸기", "잘익은 빨간 딸기", Item.ItemType.INGREDIENT));
        productList.Add(new Item(00003,12, "grapes", "포도", "보라빛의 포도", Item.ItemType.INGREDIENT));
        productList.Add(new Item(00100,1, "water", "물", "모든 음료의 기본이 되는 맑은 물", Item.ItemType.INGREDIENT));
        productList.Add(new Item(00101,10, "milk", "우유", "뼈가 튼튼해지는 우유", Item.ItemType.INGREDIENT));
        productList.Add(new Item(00005,15, "coffee", "커피콩", "모든 커피의 근본이 되는 재료", Item.ItemType.INGREDIENT));
        productList.Add(new Item(00006,20, "chocolate", "초콜렛", "달콤 씁씁한 매력의 간식이자 재료", Item.ItemType.INGREDIENT));
        productList.Add(new Item(00007,25, "ice cream", "아이스크림", "사계절 시원하게 즐기는 간식", Item.ItemType.INGREDIENT));

        deliverySlot = new DeliverySlot[productList.Count];

        for (int i = 0; i < productList.Count; i++)
        {
           var slot=Instantiate(slotPref, slotParent);
          
           deliverySlot[i]= slot.GetComponent<DeliverySlot>();
           deliverySlot[i].SetItem(productList[i]); 
            
        }


    }

    private void Update()
    {
        
    }

    private void ShowItem()
    {

    }

    private void Calculate()
    {
        for (int i = 0; i < deliverySlot.Length; i++)
        {
            tatal += deliverySlot[i].number*deliverySlot[i].price;
        }
    }
     
    public void Confirming()
    {
        Calculate();
        confirmPanel.SetActive(true);
        confirmText.text = "총" + tatal.ToString() + "골드 입니다 주문하시겠습니까 ?";
        
    }

    public void Purchase()
    {
        CafeManager.instance.gold -= tatal;
        for (int i = 0; i < deliverySlot.Length; i++)
        {
            inventory.AddItemToInven(deliverySlot[i].item, deliverySlot[i].number);
            deliverySlot[i].ResetSlot();
            tatal = 0;
        }

        confirmPanel.SetActive(false);
    }
}
