using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSeat : MonoBehaviour
{
    public GameObject go; // 테이블 객체
    public Transform[] tf; // 의자의 트랜스폼
    public bool isOccupied;

    // Start is called before the first frame update
    void Start()
    {
        go = this.gameObject;
       tf= go.GetComponentsInChildren<Transform>();
        isOccupied = false;
    }

   
}
