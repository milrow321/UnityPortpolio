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

    public int customerGroupMax;
    public List<Customer>[] customerGroup;
    private int count;

    private Customer newCus;
   

    float createTime; //손님 생성 시간

    public int createNum;//한번에 생성할 손님 수
    public int customerNum;

    private int coun;
    private int coun2;



    private void Awake()
    {
        instance = this;
        customer = customerPool.GetComponentsInChildren<Customer>();
    }

    private void Start()
    {
        customerGroupMax = 4;
        customerGroup = new List<Customer>[customerGroupMax];
        count = 0;

        coun = 0;
        coun2 = 0;
    }


    private void Update()
    {
        if (count < customerGroupMax)
        {
            if (Input.GetMouseButtonDown(1))
            {

                
                SpawnCustomer();
                coun++;
                coun2 = 0;
            }
        }
        


    }



    public void SpawnCustomer()
    {
        createNum = Random.Range(1, 5);


        for (int i = 0; i < createNum; i++)
        {
            int cusNum = Random.Range(0, customer.Length);
            newCus = Instantiate(customer[cusNum], spawner.transform.position, Quaternion.identity);
            newCus.Find(coun, coun2);
            coun2++;
            //FindSeat(newCus);
            //newCus.Move
        }
    }

    public void FindSeat(Customer _customer)
    {
        for (int i = 0; i < TablePool.instance.tableNum; i++)
        {
            if (!TablePool.instance.table[i].isOccupied)
            {
                for (int j = 0; j < TablePool.instance.table[i].chairNum; j++)
                {
                    if (!TablePool.instance.table[i].chair[j].isSeat)
                    {
                        TablePool.instance.table[i].chair[j].isSeat = true;
                        _customer.Find(i, j);

                    }
                    else continue;
                }
            }
            else continue;
        }
    }


}
