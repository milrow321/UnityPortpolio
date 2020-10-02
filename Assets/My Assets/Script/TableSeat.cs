using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSeat : MonoBehaviour
{
    static public TableSeat instance;

    

    public GameObject go; // 테이블 객체
    //public Transform[] tf; // 의자의 트랜스폼
    public bool isOccupied;
    public bool gotMenu;

    public Chair[] chair;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        go = this.gameObject;
        //tf = go.GetComponentsInChildren<Transform>();
        chair = go.GetComponentsInChildren<Chair>();
        isOccupied = false;
        gotMenu = false;
        //chair.isSeat = false;
        //chair.isSeat = false;
    }

   
}
