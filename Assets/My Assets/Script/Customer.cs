using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Customer : MonoBehaviour
{


    public float speed=10f;


    public TablePool tablePool;

    private NavMeshAgent agent;

    public Animator animator;

    public int tableCount;
    public int chairCount;

    private bool seatEmpty;
    private bool isMove;//들어오는 중인가
    public bool recieved;//주문한 음식을 받았는가

    [SerializeField]
    private bool isExit;//나가는 중인가

    private bool isOrder;//주문 하였는가

    

    private Item menuItem;//주문한 아이템(요리)

    private float time;
    private float sitTime;//앉아 있는 시간

    public OrderSlot orderSlot;

    public int numberTicket;//손님이 들어온 순서를 설정

    public Transform exitPoint;


    enum CUSTOMERSTETE
    {
        ENTER,
        SIT,
        EXIT
    }
    CUSTOMERSTETE customerState;     

    // Start is called before the first frame update
    private void Awake()
    {
       
        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        animator = GetComponentInChildren<Animator>();
        
    }

    private void Start()
    {
        customerState = CUSTOMERSTETE.ENTER;
        recieved = false;
        isMove = true;
        isExit = false;
        isOrder = false;
        //FindTable();
        //chairCount = 0;
        //tableCount=0;
}

    // Update is called once per frame
    void Update()
    {
        switch (customerState)
        {
            case CUSTOMERSTETE.ENTER:
                Move();
                break;
            case CUSTOMERSTETE.SIT:
                sitTime += Time.deltaTime;
                if (!isMove && tablePool.table[tableCount].gotMenu && !isOrder)
                {
                    Order();
                }
                Sit(tablePool.table[tableCount].chair[chairCount]);
                if (recieved) Drink();
                if (sitTime > 50f)
                {
                    
                    customerState = CUSTOMERSTETE.EXIT;
                }
                break;
            case CUSTOMERSTETE.EXIT:
                if(recieved) Pay();
                Exit();
                break;
        }



        //if (isMove && !isExit) Move(tablePool);
        //if(!isMove&&!isExit) Sit(tablePool.table[tableCount].chair[chairCount]);
        //if (recieved && !isExit && !isMove) Drink();
        //if (isExit) Exit();
        
        //if (!isMove&&tablePool.table[tableCount].gotMenu&&!isOrder)
        //{
        //    Order();
        //}

        
        
    }

    public void Move()
    {
        
        time += Time.deltaTime;
        
            agent.SetDestination(tablePool.table[tableCount].chair[chairCount].transform.position);
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            animator.transform.forward = dir;
            animator.SetBool("isMove", true);

            if (Vector3.Distance(transform.position, tablePool.table[tableCount].chair[chairCount].transform.position) < 1)
            {
                //animator.SetBool("isMove", false);
                //Sit(_tablePool.table[tableCount].chair[chairCount]);
                animator.SetBool("isMove", false);
            isMove = false;
            customerState = CUSTOMERSTETE.SIT;
            }


        

        if (time >= 10) agent.radius = 0;


    }

    private void Sit(Chair chair)
    {
        isMove = false;
        animator.SetBool("isSeat", true);
        chair.SetCustomer(this);

        var dir = chair.parentTable.transform.position-transform.position;
        animator.transform.forward = dir;
        var posZ = new Vector3(0, 1, 0);
        animator.transform.position = chair.transform.position+posZ;
        agent.radius = 0;
        
    }

    private void Order()
    {
        int[] menu= { 01001,01003, 01005, 01006, 01007, 01008 };
        int num = Random.Range(0, 6);
        
        DatabaseManager.instance.foodItemDictionary.TryGetValue(menu[num], out menuItem);

        OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].SetItem(menuItem, this);

        // orderSlot.SetItem(menuItem);

        //OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].icon.sprite = menuItem.itemImage;

        isOrder = true;
    }

    public void Find(int _tableCount, int _chairCount)
    {
        
        tableCount = _tableCount;
        chairCount = _chairCount;

    }

    //주문목록의 주문을 없애는 함수 
    private void Drink()
    {
        OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].DeleteItem();

        
        //Chair[] friends =tablePool.table[tableCount].GetComponentsInChildren<Chair>();
        //bool[] friendRecieved;
        //friendRecieved = new bool[tablePool.table[tableCount].chair.Length];

        //for (int i = 0; i < friends.Length; i++)
        //{   
        //    if (friends[i].onCustomer == null) break;
        //    friendRecieved[i] = friends[i].onCustomer.recieved;
        //}
        //for (int i = 0; i < friendRecieved.Length; i++)
        //{
        //    if (!friendRecieved[i]) return;
        //    else Pay();
        //}
        
        //Invoke("Pay()",30f);
    }

    //돈 내는 함수
    private void Pay()
    {
        CafeManager.instance.gold += 50;
        isExit = true;
        
        //Exit();
    }

    //나갈때의 움직임 함수
    private void Exit()
    {
        if(OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].item!=null)
            OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].DeleteItem();

        agent.radius = 0.3f;
        agent.SetDestination(exitPoint.position);
        
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        animator.transform.forward = dir;

        tablePool.table[tableCount].isOccupied = false;
        tablePool.table[tableCount].chair[chairCount].onCustomer = null;

        if(Vector3.Distance(transform.position,exitPoint.position)<2) Destroy(this.gameObject);
        tablePool.table[tableCount].gotMenu = false;
        animator.SetBool("isMove", true);
        animator.SetBool("isSeat", false);

    }


}
