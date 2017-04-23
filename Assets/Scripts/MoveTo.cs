using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

    public Transform goal;
    Vector3 destination;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        destination = goal.position;
        agent.destination = destination;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(destination, goal.position) > 1.0f)
        {
            destination = goal.position;
            agent.destination = destination;
        }
    }
}
