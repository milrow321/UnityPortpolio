﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomerManager : MonoBehaviour
{
    
    

    static public CustomerManager instance;

    public GameObject customerPool; //설정한 손님들이 들어있는 풀

    public Customer[] customer;//풀에 있는 손님

    public GameObject spawner;//소폰지점

    public int customerGroupMax;

    

    

    private int count;

    private Customer newCus;
   

    float createTime; //손님 생성 시간
    float spawnTime;//생성시간을 랜덤하게 할 랜덤 시간

    public int createNum;//한번에 생성할 손님 수

    [SerializeField]
    public int customerNum;//손님 들어온 순서

    private int coun; //테이블 카운트
    private int coun2; //의자카운트

    public TablePool tablePool;

    List<Table> tableAvail;

    private void Awake()
    {
        instance = this;
        customer = customerPool.GetComponentsInChildren<Customer>();
    }

    private void Start()
    {
        tableAvail = new List<Table>();

        spawnTime = Random.Range(10, 50);
        customerGroupMax = 4;
        
        count = 0;

        coun = 0;
        coun2 = 0;

        customerNum = 0;
    }


    private void Update()
    {
        createTime += Time.deltaTime;

        for (int j = 0; j < tablePool.table.Length; j++)
        {
            if (tablePool.table[j].isReserved) continue;
            else
            {
                coun = j;
                break;
            }
        }
        

        for (int i = 0; i < tablePool.table.Length; i++)
        {

            if (tablePool.table[i].isReserved) tableAvail.Add(tablePool.table[i]);
            else continue;
        }
        count = tableAvail.Count;
        tableAvail.Clear();

        if (createTime > spawnTime)
        {
            createTime = 0;
            spawnTime = Random.Range(10, 50);
            if (count < customerGroupMax)
            {

                SpawnCustomer();

                coun2 = 0;

            }
        }




        //if (Input.GetMouseButtonDown(1))
        //{

        //    if (count < customerGroupMax)
        //    {

        //        SpawnCustomer();



        //    }
        //}

        coun2 = 0;





    }

    public void SpawnCustomer()
    {
        createNum = Random.Range(1, 5);
        tablePool.table[coun].isReserved = true;

        CafeManager.instance.visitorNum += createNum;
        for (int i = 0; i < createNum; i++)
        {
            int cusNum = Random.Range(0, customer.Length);
            newCus = Instantiate(customer[cusNum], spawner.transform.position, Quaternion.identity);
            

            //newCus.Find(coun, coun2);
            newCus.tableCount = coun;
            newCus.chairCount = coun2;

            newCus.numberTicket = customerNum;
            customerNum++;
            coun2++;
            
        }
        tablePool.table[coun].setCondition(coun2);

    }



}
