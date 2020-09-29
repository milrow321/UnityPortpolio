using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Customer customer;

    public GameObject spawner;

    public List<Customer> customerGroup;

    float createTime; //손님 생성 시간

    
    
    public int createNum; //생성된 손님 수

    private void Awake()
    {
       
    }



    public Customer SpawnCustomer()
    {
        var newCus= Instantiate(customer, spawner.transform.position, Quaternion.identity);
        customerGroup.Add(newCus);
        return newCus;
    }

}
