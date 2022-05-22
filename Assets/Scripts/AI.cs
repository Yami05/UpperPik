using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
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
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("fuel").transform;
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            agent.SetDestination(target.position);

        }
        if (distance > lookRadius)
        {
            agent.SetDestination(new Vector3(0, 0, 142));
        }



       



    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

      


    


