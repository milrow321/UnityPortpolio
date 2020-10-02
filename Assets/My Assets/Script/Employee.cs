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

    // Start is called before the first frame update
    void Start()
    {

        //table = tablePool.GetComponentsInChildren<TableSeat>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < TablePool.instance.table.Length; i++)
        {
            if (TablePool.instance.table[i].isOccupied&&!TablePool.instance.table[i].gotMenu)
            {
                tableCount = i;
                PassMenu();
                break;
            }
        }
        

    }

    private void Serve()
    {
        agent.SetDestination(TablePool.instance.table[tableCount].transform.position);
    }

    private void PassMenu()
    {
        animator.SetBool("isMove", true);
        agent.SetDestination(TablePool.instance.table[tableCount].transform.position);
        if (Vector3.Distance(TablePool.instance.table[tableCount].transform.position, transform.position) < 3)
        {
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
