using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    public float speed=10f;


    public TableSeat table;


    private NavMeshAgent agent;

    public Animator animator;

  

    private bool seatEmpty; 

    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        animator = GetComponentInChildren<Animator>();
        //chairs = table.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        agent.SetDestination(table.tf[2].transform.position);

        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        animator.transform.forward = dir;
    }

    private void Order()
    {
        
    }

    


}
