using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    [SerializeField]
    public bool isOccupied;

    [SerializeField]
    public bool gotMenu;

    [SerializeField]
    public Chair[] chair;

    private int chairCount;

    public int chairNum = 4;//테이블 당 의자 갯수
    // Start is called before the first frame update

    private void Awake()
    {
        chair = gameObject.GetComponentsInChildren<Chair>();
    }


    void Start()
    {
        
        isOccupied = false;
        gotMenu = false;
    }

    private void Update()
    {
        setCondition(chairCount);
    }

    public void OnCustomerSeat(Chair _chair)
    {
        
    }

    public void setCondition(int _chairCount)
    {
        if (chair[_chairCount].IsSeat()) isOccupied = true;
    }
}
