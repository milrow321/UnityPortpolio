﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePool : MonoBehaviour
{
    static public TablePool instance; 

    private GameObject tablePool;

    [SerializeField]
    public Table[] table;
    

    public int tableNum=4;//테이블 갯수
    

    private void Awake()
    {

        instance = this;
        tablePool = this.gameObject;
        table = tablePool.GetComponentsInChildren<Table>();

        
    }
}