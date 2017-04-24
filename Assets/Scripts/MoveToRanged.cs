using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToRanged : MonoBehaviour
{
    public EnemyStats stats;
    public Transform goal;
    Vector3 destination;
    public NavMeshAgent agent;
    public float range;

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        destination = goal.position;
        agent.SetDestination(destination);
        agent.speed = stats.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled == true && Vector3.Distance(destination, goal.position) > 1.0f)
        {
            //destination = goal.position;
            destination = goal.position + Vector3.Normalize(transform.position - goal.position) * range;
            
            agent.SetDestination(destination);

        }
    }

    public void StopMoving()
    {
        agent.enabled = false;
    }

    public void StartMoving()
    {
        agent.enabled = true;
    }
}
