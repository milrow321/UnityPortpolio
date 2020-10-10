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

    

    

    public OrderPanel orders;

    public Transform counterTf;
    public CounterSlot[] counterSlot;

    public TablePool tablePool;

    // Start is called before the first frame update
    void Start()
    {

        counterSlot = counterTf.GetComponentsInChildren<CounterSlot>();
        //table = tablePool.GetComponentsInChildren<TableSeat>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        tableDesPos = new Vector3(-2, 0, 1);

       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tablePool.table.Length; i++)
        {
            if (tablePool.table[i].isOccupied&&!tablePool.table[i].gotMenu)
            {
                tableCount = i;
                //Invoke("PassMenu", 10f);

                PassMenu();
                break;
            }
        }

        for (int i = 0; i < counterSlot.Length; i++)
        {
            if (counterSlot[i].Serving() != null && !counterSlot[i].Serving().recieved)
            {
                
                Serve(counterSlot[i].Serving());
                counterSlot[i].EraseItem();
                break;
            }
        }
       

    }

    private void Serve(Customer customer)
    {
        
        agent.SetDestination(customer.transform.position);
        if (Vector3.Distance(transform.position, customer.transform.position) < 2)
        {
            customer.recieved = true;
            
            BackToCount();
        }
    }

    private void PassMenu()
    {
        animator.SetBool("isMove", true);
        agent.SetDestination(tablePool.table[tableCount].transform.position+ tableDesPos);
        if (Vector3.Distance(tablePool.table[tableCount].transform.position+ tableDesPos, transform.position) < 1)
        {
            var dir = tablePool.table[tableCount].transform.position - transform.position;
            animator.transform.forward = dir;
            animator.SetBool("isMove", false);
            tablePool.table[tableCount].gotMenu = true;
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
