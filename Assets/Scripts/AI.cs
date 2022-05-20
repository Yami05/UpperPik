using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform fuel;

    public LayerMask WhatIsGround, WhatIsFuel;


    public Vector3 runPoint;
    bool runPointSet;
    public float runPointRange;

    public float sightRange;
    public bool fuelInSightRange;

    private void Awake()
    {
        fuel = GameObject.FindGameObjectWithTag("fuel").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        fuelInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsFuel);
        if (!fuelInSightRange)
        {
            Running();
        }
    }
    private void Running()
    {
       
        if (!runPointSet)
        {
            RunThrough();

        }
        if (runPointSet)
        {
            agent.SetDestination(runPoint);

            Vector3 distanceToFinishPoint = transform.position - runPoint;
            if (distanceToFinishPoint.magnitude<1f)
            {
                runPointSet = false;
            }
        }

    }
    private void RunThrough()
    {
        runPoint = new Vector3(0, 0, 100 );
        runPointSet = true;
    }

    private void RunToFuel()
    {
        agent.SetDestination(fuel.position);
        transform.LookAt(fuel);
    }

}
