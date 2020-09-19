using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grocery : MonoBehaviour
{
    public Transform slotRoot;

    private List<Slot> slots;


    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();

        int slotCount = slotRoot.childCount;

        for (int i = 0; i < slotCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

  
}
