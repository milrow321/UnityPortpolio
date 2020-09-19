using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Communication : MonoBehaviour
{
    public Text script;
    public Animator coummucation_Ani;
    public Camera camera;

    public GameObject ShopUI;

    bool isTalk;
    int talk_count;

    RaycastHit hitInfo;

    //private void Awake()

    //{
    //    camera = Camera.main;
    //}

    // Update is called once per frame
    void Update()
    {
        Talk();
    }

    void Talk()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        if (Physics.Raycast(camera.ScreenPointToRay(mousePos), out hitInfo));
        {
            if (hitInfo.transform.CompareTag("NPC"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ShopUI.SetActive(true);
                }
            }
        }
    }
}
