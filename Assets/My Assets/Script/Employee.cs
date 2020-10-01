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

    public GameObject tablePool;

    [SerializeField]
    private TableSeat[] table;

    [SerializeField]
    public Transform counter;

    private int tableCount;
    private int chairCount;

    public Transform defPos;

    // Start is called before the first frame update
    void Start()
    {

        table = tablePool.GetComponentsInChildren<TableSeat>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < table.Length; i++)
        {
            if (table[i].isOccupied&&!table[i].gotMenu)
            {
                tableCount = i;
                PassMenu();
                break;
            }
        }
        

    }

    private void Serve()
    {
        agent.SetDestination(table[tableCount].transform.position);
    }

    private void PassMenu()
    {
        animator.SetBool("isMove", true);
        agent.SetDestination(table[tableCount].transform.position);
        if (Vector3.Distance(table[tableCount].transform.position, transform.position) < 3)
        {
            animator.SetBool("isMove", false);
            table[tableCount].gotMenu = true;
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
