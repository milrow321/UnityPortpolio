using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range; //습득 가능 거리

    private bool pickupActivated = false;
    private Camera camera;

    private RaycastHit hitInfo;

    [SerializeField]
    private LayerMask layerMask;

    private Text fallenItemName; //떨어져있는 아이템 이름


    [SerializeField]
    private Inventory theInventory;


    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CheckItem()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

        if (Physics.Raycast(camera.ScreenPointToRay(mousePos), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else ItemInfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        fallenItemName.gameObject.SetActive(true);
        fallenItemName.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName; 
    }

    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        fallenItemName.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {

                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}


