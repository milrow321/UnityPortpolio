using System.Collections;
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

    public int createNum;//한번에 생성할 손님 수
    public int customerNum;

    private int coun; //테이블 카운트
    private int coun2; //의자카운트

    public TablePool tablePool;

    private void Awake()
    {
        instance = this;
        customer = customerPool.GetComponentsInChildren<Customer>();
    }

    private void Start()
    {
     
        
        
        customerGroupMax = 4;
        
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

                //if (coun > TablePool.instance.table.Length) coun = 0;
                SpawnCustomer();
                coun++;
                coun2 = 0;
                
            }
        }

       
        //for (int i = 0; i < TablePool.instance.table.Length; i++)
        //{
        //    if (TablePool.instance.table[i].chair[createNum].isSeat)
        //    {
        //        TablePool.instance.table[i].isOccupied = true;
        //    }
        //}
        

    }



    public void SpawnCustomer()
    {
        createNum = Random.Range(1, 5);


        for (int i = 0; i < createNum; i++)
        {
            int cusNum = Random.Range(0, customer.Length);
            newCus = Instantiate(customer[cusNum], spawner.transform.position, Quaternion.identity);
            newCus.Find(coun, coun2);
            newCus.numberTicket = coun * 4 + coun2;
            coun2++;
            
        }
        //tablePool.table[coun].isOccupied=true;
        tablePool.table[coun].setCondition(coun2);
    }

    public void SetCustomerSeat()
    {

    }


}
