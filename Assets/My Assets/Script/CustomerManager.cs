using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomerManager : MonoBehaviour
{
    static public CustomerManager instance;

    public GameObject customerPool;

    public Customer[] customer;

    public GameObject spawner;

    public List<Customer> customerGroup;

    //public int createNum; //생성된 손님 수

    float createTime; //손님 생성 시간

    public int createNum;

    private void Awake()
    {
        instance = this;
        customer = customerPool.GetComponentsInChildren<Customer>();
    }


    

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SpawnCustomer();
        }
        
    }



    public void SpawnCustomer()
    {
        createNum = Random.Range(1, 5);
        for (int i = 0; i < createNum; i++)
        {
            int cusNum = Random.Range(0, customer.Length);
            var newCus = Instantiate(customer[cusNum], spawner.transform.position, Quaternion.identity);
            
            //customerGroup.Add(newCus);
        }
    }

    public void DeleteCustomer()
    {
        customerGroup.Clear();

    }
}
