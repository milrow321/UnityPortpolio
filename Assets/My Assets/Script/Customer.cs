using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Customer : MonoBehaviour
{
    public float speed=10f;

    public GameObject tablePool;

    [SerializeField]
    private TableSeat[] table;


    private NavMeshAgent agent;

    public Animator animator;

    private int tableCount;
    private int chairCount;

    private bool seatEmpty;
    private bool isMove;

    // Start is called before the first frame update
    private void Awake()
    {
        table = tablePool.GetComponentsInChildren<TableSeat>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        animator = GetComponentInChildren<Animator>();
        //chairs = table.GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        isMove = true;
        //FindTable();
        chairCount = 0;
        tableCount=0;
}

    // Update is called once per frame
    void Update()
    {





        if (isMove)
        {
            Move();
        }


        if (table[tableCount].chair[chairCount].isSeat) chairCount++;
        if (CustomerManager.instance.createNum==chairCount)
        {
            table[tableCount].isOccupied = true;
            tableCount++;
            chairCount = 0;
        }
    }

    private void Move()
    {
        

        if (Vector3.Distance(transform.position, table[tableCount].chair[chairCount].transform.position) < 1)
        {
            isMove = false;
            Sit();
            animator.SetBool("isMove", false);
            table[tableCount].chair[chairCount].isSeat = true;
        }
        else 
        {
            agent.SetDestination(table[tableCount].chair[chairCount].transform.position);
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            animator.transform.forward = dir;
            animator.SetBool("isMove", true);
        }
    }

    private void Sit()
    {
        
    
        //agent.SetDestination(table[tableCount].chair[chairCount].transform.position);
       
        //animator.transform.position = table[tableCount].tf[chairCount].transform.position ;
        animator.SetBool("isSeat", true);
        
    }

    private void Order()
    {
        
    }

    private void FindTable()
    {
        for (int i = 0; i < table.Length; i++)
        {
            if (table[i].isOccupied) continue;
            else
            {
                tableCount = i;
                break;
            }
        }

    }

    private void FindChair()
    {
        
    }


}
