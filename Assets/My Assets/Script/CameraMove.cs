using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour 
{

    Camera cam;
    Vector3 prePos, newPos;
    Vector3 movePos;

    public GameObject cookUI;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!cookUI.activeSelf)
        {
            //if (transform.position.x > -4 || transform.position.x < 10 || transform.position.y > 10 || transform.position.y < 30)
            

            if (Input.GetMouseButtonDown(0))
            {
                prePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
                cam.WorldToScreenPoint(prePos);

            }
            else if (Input.GetMouseButton(0))
            {
                movePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
                cam.WorldToScreenPoint(movePos);
                //transform.Translate((prePos - movePos) * Time.deltaTime * 0.5f);
                transform.position -= (movePos - prePos).normalized * Time.deltaTime * 15f;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -25, -11), Mathf.Clamp(transform.position.y, 20, 25), Mathf.Clamp(transform.position.z,-20,20));
               
            }
            else if (Input.GetMouseButtonUp(0))
            {

            }
        }

    }

    




}
