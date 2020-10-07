using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Employee : MonoBehaviour
{
    public Animator animator;
    public float speed = 10;
    private NavMeshAgent agent;

    //public GameObject tablePool;

    //[SerializeField]
    //private TableSeat[] table;



    [SerializeField]
    public Transform counter;

    private int tableCount;
    private int chairCount;

    public Transform defPos;

    private Vector3 tableDesPos;

    public Transform counterTf;

    [SerializeField]
    private CounterSlot[] counterFoods;

    public OrderPanel orders;

    [SerializeField]
    private OrderSlot[] orderSlots;

    // Start is called before the first frame update
    void Start()
    {
       

        //table = tablePool.GetComponentsInChildren<TableSeat>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        tableDesPos = new Vector3(-2, 0, 1);

        counterFoods = counterTf.GetComponentsInChildren<CounterSlot>();
        orderSlots = orders.GetComponentsInChildren<OrderSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < TablePool.instance.table.Length; i++)
        {
            if (TablePool.instance.table[i].isOccupied&&!TablePool.instance.table[i].gotMenu)
            {
                tableCount = i;
                Invoke("PassMenu", 10f);

                //PassMenu();
                break;
            }
        }

        for (int i = 0; i < counterFoods.Length; i++)
        {
            for (int j = 0; j < orderSlots.Length; j++)
            {
                if (counterFoods[i] != null && orderSlots[j] != null)
                {
                    if (orderSlots[j].item==counterFoods[i].item)
                    {
                        orderSlots[j].DeleteItem();
                        counterFoods[i].EraseItem();
                    }
                }
            }
        }
       

    }

    private void Serve()
    {
        agent.SetDestination(TablePool.instance.table[tableCount].transform.position+ tableDesPos);
    }

    private void PassMenu()
    {
        animator.SetBool("isMove", true);
        agent.SetDestination(TablePool.instance.table[tableCount].transform.position+ tableDesPos);
        if (Vector3.Distance(TablePool.instance.table[tableCount].transform.position+ tableDesPos, transform.position) < 1)
        {
            var dir = TablePool.instance.table[tableCount].transform.position - transform.position;
            animator.transform.forward = dir;
            animator.SetBool("isMove", false);
            TablePool.instance.table[tableCount].gotMenu = true;
            Invoke("BackToCount",3f);
        }
    }

    private void BackToCount()
    {
        animator.SetBool("isMove", true);
        agent.SetDestination(defPos.position);
        if (Vector3.Distance(defPos.position, transform.position) < 2)
        {
            animator.SetBool("isMove", false);

        }
    }
}
