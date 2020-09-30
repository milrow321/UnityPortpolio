using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Customer customer;

    public GameObject spawner;

    public List<Customer> customerGroup;

    float createTime; //손님 생성 시간



    //public int createNum; //생성된 손님 수

    private void Update()
    {
        
    }



    public void SpawnCustomer()
    {
        int createNum = Random.Range(1, 5);
        for (int i = 0; i < createNum; i++)
        {
            var newCus = Instantiate(customer, spawner.transform.position, Quaternion.identity);
            customerGroup.Add(newCus);
        }
    }

    public void DeleteCustomer()
    {
        customerGroup.Clear();

    }
}
