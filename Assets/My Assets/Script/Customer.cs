using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Customer : MonoBehaviour
{
    public float speed=10f;

    


    private NavMeshAgent agent;

    public Animator animator;

    public int tableCount;
    public int chairCount;

    private bool seatEmpty;
    private bool isMove;

    private Item menuItem;//주문한 아이템(요리)

    // Start is called before the first frame update
    private void Awake()
    {   

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        animator = GetComponentInChildren<Animator>();
        
    }

    private void Start()
    {
        isMove = true;
        //FindTable();
        //chairCount = 0;
        //tableCount=0;
}

    // Update is called once per frame
    void Update()
    {


        Move(tablePool);


        //if (isMove)
        //{
        //    Move();
        //}
        //if (TablePool.instance.table[tableCount].gotMenu)
        //{
        //    Order();
        //}
        

    }

    public void Move(TablePool _tablePool)
    {
        agent.SetDestination(_tablePool.table[tableCount].chair[chairCount].transform.position);
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        animator.transform.forward = dir;
        animator.SetBool("isMove", true);

        //if (Vector3.Distance(transform.position, des) < 1)
        //{
        //    animator.SetBool("isMove", false);
        //    Sit();

        //}

        //agent.SetDestination(TablePool.instance.table[tableCount].chair[chairCount].transform.position);
        //var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        //animator.transform.forward = dir;
        //animator.SetBool("isMove", true);

        //if (Vector3.Distance(transform.position, TablePool.instance.table[tableCount].chair[chairCount].transform.position) < 1)
        //{
        //    animator.SetBool("isMove", false);
        //    Sit();

        //}

    }

    private void Sit(Chair chair)
    {
        animator.SetBool("isMove", false);
        isMove = false;
        animator.SetBool("isSeat", true);
        chair.SetCustomer(this);

        var dir = chair.parentTable.transform.position-transform.position;
        agent.transform.forward = dir;
        var posZ = new Vector3(0, 3, 0);
        agent.transform.position = chair.transform.position+posZ;
        
    }

    private void Order()
    {
        int menu = 01000;
        
        DatabaseManager.instance.foodItemDictionary.TryGetValue(menu, out menuItem);
        
        OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].icon.sprite = menuItem.itemImage;
        Color color = OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].GetComponent<Image>().color;
        color.a = 1f;
        OrderPanel.instance.orderSlotPanels[tableCount].slot[chairCount].icon.color = color;

    }

    public void Find(int _tableCount, int _chairCount)
    {
        
        tableCount = _tableCount;
        chairCount = _chairCount;

    }

    private void Exit()
    {
        
    }


}
