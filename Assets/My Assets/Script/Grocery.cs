using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grocery : MonoBehaviour
{
    

    public Transform slotRoot;
    public GameObject purchasePanel;
    
    private List<Item> productList;


    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        //slots = new List<Slot>();

        //int slotCount = slotRoot.childCount;

        //for (int i = 0; i < slotCount; i++)
        //{
        //    var slot = slotRoot.GetChild(i).GetComponent<Slot>();

        //    slots.Add(slot);
        //}

        //purchasePanel = GetComponentInChildren<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        if (Physics.Raycast(camera.ScreenPointToRay(mousePos), out hitInfo))
        {
            if (hitInfo.transform.CompareTag("Slot"))
            {
                if (Input.GetMouseButtonDown(0))
                { 
                }
            }
        }

    }

    private void OnClickSlot(Slot slot)
    {
        purchasePanel.SetActive(true);
        
    }

    private void OnPurchasePanel()
    {
        
    }


    private void Purchase()
    {
        
    }
  
}
