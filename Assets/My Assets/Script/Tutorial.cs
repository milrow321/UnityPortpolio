using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Button cookUIButton;
    public Button recipeUIButton;
    public Button groceryUIButton;
    public Button orderUIButton;
    public Button counterUIButton;
    

    public GameObject kitchen;
    public GameObject counter;
    public GameObject recipe;
    public GameObject order;
    public Grocery grocery;
    public GameObject customerManager;


    public CounterSlot sampleCounterSlot;
    public CounterSlot sampleCounterSlot2;

    public RectTransform downArrow;
    public RectTransform upArrow;
    public RectTransform leftArrow;

    public OrderSlot orderSlot;

    private Text guideText;
    private RectTransform rect;
    private int step=0;

    private Vector3 outPos;
    private Vector3 centerPos;
    private Vector3 rightPos;
    
    private Vector3 leftUpPos;
    private Vector3 leftDownPos;
    private Vector3 midUpPos;
    private Vector3 midPos;

    private Vector3 ArrowPos1;
    private Vector3 ArrowPos2;
    private Vector3 ArrowPos3;
    private Vector3 ArrowPos4;
    private Vector3 ArrowPos5;
    private Vector3 ArrowPos6;
    private Vector3 ArrowPos7;

   

   

    // Start is called before the first frame update
    void Start()
    {
        outPos = new Vector3(600, 0, 0);

        centerPos = new Vector3(3, 14, 0);
        rightPos = new Vector3(245, -40, 0);
        leftUpPos = new Vector3(-250, 70, 0);
        leftDownPos = new Vector3(-250, -70, 0);
        midPos = new Vector3(-55, 88, 0);
        midUpPos = new Vector3(-110, 155, 0);

        ArrowPos1 = new Vector3(325, -115, 0);
        ArrowPos2 = new Vector3(240, -115, 0);
        ArrowPos3 = new Vector3(160, -115, 0);
        ArrowPos4 = new Vector3(-150, 6, 0);
        ArrowPos5 = new Vector3(-370, 130, 0);
        ArrowPos6 = new Vector3(-115, -60, 0);
        ArrowPos7 = new Vector3(-0, -60, 0);

        guideText = GetComponentInChildren<Text>();
        rect = GetComponent<RectTransform>();


        downArrow.anchoredPosition = outPos;
        leftArrow.anchoredPosition = outPos;
        upArrow.anchoredPosition = outPos;
        rect.anchoredPosition = centerPos;
        guideText.text = "CafeInU에 어서오세요";

        cookUIButton.interactable=false;
        recipeUIButton.interactable = false;
        groceryUIButton.interactable = false;
        orderUIButton.interactable = false;
        counterUIButton.interactable = false;
        customerManager.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
        switch (step)
        {
                
            case 0 :
                   
                if (Input.GetMouseButtonDown(0)) step++;
                    
                break;
                
            case 1:
                    
                guideText.text = "간단히 게임방법을 알려드리겠습니다";
                   
                if (Input.GetMouseButtonDown(0)) step++;
                   
                break;
               
            case 2:
                
                            
                rect.anchoredPosition = rightPos;                
                               
                downArrow.anchoredPosition = ArrowPos1;                
                guideText.text = "먼저 주방을 들어가 볼까요?";               
                cookUIButton.interactable = true;
                if(kitchen.activeSelf) step++;
                
                break;
                
            case 3:                   
                                   
                rect.anchoredPosition = midUpPos;                                                   
                downArrow.anchoredPosition = outPos;                    
                guideText.text = "재료를 드래그해서 조합창으로 옮길 수 있습니다";                
                if (Input.GetMouseButtonDown(0)) step++;                   
                break;
                
            case 4:                  
                guideText.text = "딸기와 물을 순서대로 옮기고 COOK버튼을 눌러보세요" ;              
                if (Input.GetMouseButtonDown(0)) step++;             
                break;
            case 5:
                guideText.text = "휴지통 버튼으로 조합슬롯을 리셋할 수 있습니다";
                if (sampleCounterSlot.item != null) step++;
                break;
            case 6:
                counterUIButton.interactable = true;
                
                rect.anchoredPosition = leftUpPos;
                
                upArrow.anchoredPosition = ArrowPos5;
                guideText.text = "완성된 요리는 카운터에서 볼 수 있습니다";
                if (counter.activeSelf) step++;
                break;
            case 7:
                upArrow.anchoredPosition = outPos;
                guideText.text = "완성된 딸기주스가 올라갔습니다. 카운터를 접고 주방을 나가봅시다";
                if (!kitchen.activeSelf) step++;
                break;
            case 8:
                recipeUIButton.interactable = true;
                rect.anchoredPosition = rightPos;
                downArrow.anchoredPosition = ArrowPos3;
                guideText.text = "요리법은 레시피를 통해 확인할 수 있습니다";
                if (recipe.activeSelf) step++;
                break;
            case 9:


                rect.anchoredPosition = midPos;
                downArrow.anchoredPosition = outPos;
                guideText.text = "레시피에 나온 순서대로 재료를 조합해야 요리를 할 수 있습니다";
                if (Input.GetMouseButtonDown(0)) step++;
                break;
            case 10:
                guideText.text = "발견되지 않은 레시피는 추후에 해금할 수 있습니다";
                if (Input.GetMouseButtonDown(0)) step++;
                break;
            case 11:
                guideText.text = "X버튼을 눌러 레시피북을 닫아봅시다";
                if (!recipe.activeSelf) step++;
                break;
            case 12:
                orderUIButton.interactable = true;
                customerManager.SetActive(true);
                rect.anchoredPosition = leftDownPos;            
                downArrow.anchoredPosition = ArrowPos6;
                guideText.text = "주문 목록패널을 열어봅시다";
                if(order.activeSelf) step++;
                break;
            case 13:
                
                rect.anchoredPosition = midUpPos;
               
                downArrow.anchoredPosition = outPos;
                guideText.text = "손님이 주문하면 패널에 주문한 메뉴가 뜹니다. 손님을 기다려보죠";
                if(orderSlot.item != null) step++;
                break;
            case 14:
                guideText.text = "주문이 들어왔습니다. 요리를 만들어 손님에게 대접해보죠";
                if (kitchen.activeSelf) step++;
                break;
            case 15:
                
                rect.anchoredPosition = outPos;
                if (sampleCounterSlot2.item != null) step++;
                break;
            case 16:
                
                rect.anchoredPosition = leftUpPos;
                
                
                guideText.text = "카운터 슬롯을 클릭하면 손님에게 서빙할 수 있습니다";
                if (sampleCounterSlot2.item == null) step++;
                break;
            case 17:
                guideText.text = "손님들이 화를 내며 나가기 전에 요리를 서빙해야합니다";
                if (Input.GetMouseButtonDown(0)) step++;
                break;
            case 18:
                groceryUIButton.interactable = true;
                
                rect.anchoredPosition = rightPos;
                
                downArrow.anchoredPosition = ArrowPos2;
                guideText.text = "이제 재료구매 버튼을 눌러봅시다";
                if (grocery.gameObject.activeSelf) step++;
                break;
            case 19:
                downArrow.anchoredPosition = outPos;
                guideText.text = "이곳에서 재료를 구매 할 수 있습니다";
                if (Input.GetMouseButtonDown(0)) step++;
                break;
            case 20:
                guideText.text = "원하는 만큼 재료 수량을 설정하고 구매하기로 구매해봅시다";
                if (grocery.confirmPanel.activeSelf) step++;
                break;
            case 21:
                guideText.text = "구매한 아이템은 인벤토리에 자동으로 추가됩니다";
                if (Input.GetMouseButtonDown(0)) step++;
                break;
            case 22:
                guideText.text = "이제 나가기를 눌러 상점 패널을 종료합시다";
                if (!grocery.gameObject.activeSelf) step++;
                break;
            case 23:
                guideText.text = "듀토리얼이 끝났습니다. 이제 자유롭게 게임을 즐겨주세요";
                if (Input.GetMouseButtonDown(0)) step++;
                break;
            case 24:
                this.gameObject.SetActive(false);
                break;
            }

        
    }
}
