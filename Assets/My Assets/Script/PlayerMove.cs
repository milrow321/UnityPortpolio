using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    Camera camera;
    private Animator animator;
    private NavMeshAgent agent;

    CharacterController cc;

    private bool isMove;
    private Vector3 destination;

    //플레이어 능력치
    public float MoveSpeed = 10.0f;
    public int hp=50;
    public int mp = 25;
    public float STR = 10;
    public float INT = 10;
    public float DEF = 10;
    public float COOK = 1;

    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit)) ;
            {
                setDestination(hit.point);

            }
        }
       

        LookMoveDirection();
    }

    private void setDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
        animator.SetBool("isMove", true);
    }

    private void LookMoveDirection()
    {
        if (isMove)
        {
            if (agent.velocity.magnitude == 0f)
            {
                isMove = false;
                animator.SetBool("isMove", false);
                return;
            }

            var dir = new Vector3(agent.steeringTarget.x, transform.position.y,agent.steeringTarget.z) - transform.position;
            animator.transform.forward = dir;
            //transform.position += dir.normalized * Time.deltaTime * MoveSpeed;
        }
        
    }
}
