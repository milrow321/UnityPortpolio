using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Customer : MonoBehaviour
{

    
    

    private NavMeshAgent agent;

    public Animator animator;

    private bool seatEmpty;
    private bool isMove;

    private Item orderItem;//주문한 아이템(요리)
    private Item recieveItem; //서빙 받은 아이템(요리)

    private float time;

    // Start is called before the first frame update
    private void Awake()
    {        
        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        animator = GetComponentInChildren<Animator>();
        isMove = true;
    }

   
    

    public void Move(Vector3 des)
    {
        time += Time.deltaTime;

        agent.SetDestination(des);
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        animator.transform.forward = dir;
        animator.SetBool("isMove", true);

        if (Vector3.Distance(transform.position, des) < 1)
        {
            animator.SetBool("isMove", false);
            isMove = false;
        }

        if (time >= 10) agent.radius=0;
        
    }

    private void Sit(Chair chair)
    {
        
        animator.SetBool("isSeat", true);
        chair.SetCustomer(this);

        var dir = chair.parentTable.transform.position-transform.position;
        animator.transform.forward = dir;
        var posZ = new Vector3(0, 1, 0);
        agent.transform.position = chair.transform.position+posZ;
        agent.radius = 0;
    }

    private Item Order()
    {
        int menu = 01000; //랜덤하게 뽑을 아이템ID
        
        DatabaseManager.instance.foodItemDictionary.TryGetValue(menu, out orderItem);
        return orderItem;
    }

    private void Drink(Item _recieveItem)
    {
        recieveItem = _recieveItem;
        
    }

    
    private void Exit()
    {
        Destroy(this);
    }


    //public void Find(int _tableCount, int _chairCount)
    //{

    //    tableCount = _tableCount;
    //    chairCount = _chairCount;

    //}

}
