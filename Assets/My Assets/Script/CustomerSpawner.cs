using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPool; //설정한 손님들이 들어있는 풀

    public Customer[] customer;//풀에 있는 손님

    //public GameObject spawner;//스폰지점

    public int customerGroupMax; //가게에 들어올 수 있는 최대 손님그룹 수





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
            newCus = Instantiate(customer[cusNum], transform.position, Quaternion.identity);
            newCus.Find(coun, coun2);
            coun2++;
        }
        
    }
  
}
