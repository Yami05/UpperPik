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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        stack = bot.GetComponent<Stack>();
        animator.SetBool("isMoving", true);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {


       

        agent.Move(transform.forward * Time.deltaTime * 10);


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
   
}

      


    


