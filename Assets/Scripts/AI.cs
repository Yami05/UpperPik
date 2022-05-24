using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public float lookRadius = 10f;
    
    NavMeshAgent agent;

    Animator animator;
    public GameObject bot;
    Stack stack;
    Transform target;
    
    
    
    void Start()
    {
        
        
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        stack = bot.GetComponent<Stack>();
        animator.SetBool("isMoving", true);
        target = GameObject.FindGameObjectWithTag("fuel").transform; // i know  this is the not best solution for optimization

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (agent.isOnOffMeshLink)
        {
            agent.speed = 4;
            if (stack._fuels.Count<=1)
            {
                agent.enabled = false;
            }
        }
        else
        {
            agent.speed = 1;
        }
            agent.Move(transform.forward * Time.deltaTime * 9);
            
        



    }
    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance<= lookRadius)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(new Vector3(0,0,142));
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
   
   
}

      


    


