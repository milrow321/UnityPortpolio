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
    private bool isMove;
    public bool recieved;

    private Item menuItem;//주문한 아이템(요리)

    private float time;

    public OrderSlot orderSlot;

    public int numberTicket;//손님이 들어온 순서를 설정

    // Start is called before the first frame update
    private void Awake()
    {
       
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        animator = GetComponentInChildren<Animator>();
        
    }

    private void Start()
    {
        recieved = false;
        isMove = true;
        //FindTable();
        //chairCount = 0;
        //tableCount=0;
}

    // Update is called once per frame
    void Update()
    {


        if (isMove) Move(tablePool);
        else Sit(tablePool.table[tableCount].chair[chairCount]);

        //if (isMove)
        //{
        //    Move();
        //}
        if (TablePool.instance.table[tableCount].gotMenu)
        {
            Order();
        }

        if (recieved) Drink();

    }

    public void Move(TablePool _tablePool)
    {
        time += Time.deltaTime;

        agent.SetDestination(_tablePool.table[tableCount].chair[chairCount].transform.position);
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        animator.transform.forward = dir;
        animator.SetBool("isMove", true);

        if (Vector3.Distance(transform.position, _tablePool.table[tableCount].chair[chairCount].transform.position) < 1)
        {
            //animator.SetBool("isMove", false);
            //Sit(_tablePool.table[tableCount].chair[chairCount]);
            animator.SetBool("isMove", false);
            isMove = false;
        }

        if (time >= 10) agent.radius=0;

        

    }

    private void Sit(Chair chair)
    {
        
        animator.SetBool("isSeat", true);
        chair.SetCustomer(this);

        var dir = chair.parentTable.transform.position-transform.position;
        animator.transform.forward = dir;
        var posZ = new Vector3(0, 1, 0);
        agent.transform.position = chair.transform.position+posZ;
        agent.radius = 0;
    }

    private void Order()
    {
        int menu = 01000;
        
        DatabaseManager.instance.foodItemDictionary.TryGetValue(menu, out menuItem);

        OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].SetItem(menuItem, this);

       // orderSlot.SetItem(menuItem);

        //OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].icon.sprite = menuItem.itemImage;
        

    }

    public void Find(int _tableCount, int _chairCount)
    {
        
        tableCount = _tableCount;
        chairCount = _chairCount;

    }

    private void Drink()
    {
        OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].DeleteItem();
        Invoke("Pay()",30f);
    }

    private void Pay()
    { 

    }

    private void Exit()
    {
        
    }


}
