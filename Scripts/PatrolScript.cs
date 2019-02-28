using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : MonoBehaviour {

    private int destPoint = 0;
    public Rigidbody monster;
    public int monstersTotal = 0;
    private NavMeshAgent agent;
    List<GameObject> waypoints;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("Spawner").ToList();


        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        //agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (waypoints.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = waypoints[destPoint].transform.position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % waypoints.Count;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        agent.isStopped = monstersTotal <= 0;
        if (!agent.isStopped && !agent.pathPending && agent.remainingDistance ==0)
            GotoNextPoint();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawner")
        {
            Instantiate(monster, other.transform.position, gameObject.transform.rotation);
            monstersTotal--;
        }
    }
}
