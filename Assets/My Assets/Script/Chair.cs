using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public Table parentTable; 
    public Customer onCustomer;

    public bool IsSeat()
    {
        return onCustomer != null;
    }

    private void Start()
    {
        onCustomer = null;
        parentTable = transform.parent.GetComponent<Table>();
    }

    public void SetCustomer(Customer customer)
    {
        if (onCustomer != null)
            return;

        onCustomer = customer;

        if (parentTable != null)
            parentTable.OnCustomerSeat(this);
    }

}
