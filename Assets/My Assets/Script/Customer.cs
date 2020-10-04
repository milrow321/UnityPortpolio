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





        if (isMove)
        {
            Move();
        }
        if (TablePool.instance.table[tableCount].gotMenu)
        {
            Order();
        }
        

    }

    public void Move()
    {
        

        agent.SetDestination(TablePool.instance.table[tableCount].chair[chairCount].transform.position);
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        animator.transform.forward = dir;
        animator.SetBool("isMove", true);

        if (Vector3.Distance(transform.position, TablePool.instance.table[tableCount].chair[chairCount].transform.position) < 1)
        {
            animator.SetBool("isMove", false);
            Sit();
            
        }

    }

    private void Sit()
    {


        

        isMove = false;
        animator.SetBool("isSeat", true);
        TablePool.instance.table[tableCount].chair[chairCount].isSeat = true;
        //if (chairCount == CustomerManager.instance.createNum)
        //{
        //    TablePool.instance.table[tableCount].isOccupied = true;
        //    chairCount = 0;
        //}
    }

    private void Order()
    {
        int menu = 01000;
        Item menuItem;
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

    private void FindChair()
    {
        
    }


}
