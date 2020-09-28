using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{

    public TableSeat table;


    private NavMeshAgent agent;

    public Animator animator;

    private bool seatEmpty; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {

        agent.SetDestination(table.tf[0].transform.position);
        
    }

    private void Order()
    {

    }


}
