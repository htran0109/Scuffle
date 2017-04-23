using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

    public Transform goal;
    Vector3 destination;
    public NavMeshAgent agent;

    // Use this for initialization
    void Awake () {
        agent = GetComponent<NavMeshAgent>();
        destination = goal.position;
        agent.SetDestination(destination);
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(destination, goal.position) > 1.0f)
        {
            destination = goal.position;
            Debug.Log(destination);
            Debug.Log(agent);
            agent.SetDestination(destination);
        }
    }
}
