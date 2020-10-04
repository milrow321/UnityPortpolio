using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    static public Table instance;

    [SerializeField]
    public bool isOccupied;

    [SerializeField]
    public bool gotMenu;

    [SerializeField]
    public Chair[] chair;

    public int chairNum = 4;//테이블 당 의자 갯수
    // Start is called before the first frame update

    private void Awake()
    {
        chair = gameObject.GetComponentsInChildren<Chair>();
    }


    void Start()
    {
        instance = this;
        isOccupied = false;
        gotMenu = false;
    }
}
