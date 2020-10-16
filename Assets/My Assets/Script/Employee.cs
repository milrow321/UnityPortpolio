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



    bool isReturn;//다시 돌아가는 행동

    private int tableCount;
    private int chairCount;

    public Transform defPos;

    private Vector3 tableDesPos;

    private Vector3 defaltDir;//기본상태에서 바라보는 방향

    

    public OrderPanel orders;

    public Transform counterTf;
    public CounterSlot[] counterSlot;

    public TablePool tablePool;

    float tempTime;//메뉴전달 함수의 약간 텀을 주기 위함

    // Start is called before the first frame update
    void Start()
    {

        counterSlot = counterTf.GetComponentsInChildren<CounterSlot>();
        //table = tablePool.GetComponentsInChildren<TableSeat>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        tableDesPos = new Vector3(-2, 0, 2);

        defaltDir = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReturn) Invoke("BackToCount", 3f); //BackToCount();

        for (int i = 0; i < tablePool.table.Length; i++)
        {
            
            if (tablePool.table[i].isOccupied && !tablePool.table[i].gotMenu)
            {
                tempTime += Time.deltaTime;
                tableCount = i;
                //Invoke("PassMenu", 10f);
                if (tempTime >= 1.5f)
                {
                    PassMenu();
                    tempTime = 0;
                    break;
                }
            }
            else continue;
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
        if (Vector3.Distance(transform.position, customer.transform.position) < 3)
        {
            customer.recieved = true;

            //BackToCount();
            isReturn = true;
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
            //Invoke("BackToCount", 3f);
            isReturn = true;
        }
    }

    private void BackToCount()
    {
        
        animator.SetBool("isMove", true);
        agent.SetDestination(defPos.position);
        if (Vector3.Distance(transform.position, defPos.position) < 1)
        {
            animator.SetBool("isMove", false);
            agent.transform.forward = defaltDir;
            isReturn = false;
        }
        
    }
}
