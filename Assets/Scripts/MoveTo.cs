using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

    public EnemyStats stats;
    public Transform goal;
    Vector3 destination;
    public NavMeshAgent agent;
    public int damage;

    // Use this for initialization
    void Awake () {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        destination = goal.position;
        agent.SetDestination(destination);
        agent.speed = stats.speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (agent.enabled == true && Vector3.Distance(destination, goal.position) > 1.0f)
        {
            destination = goal.position;
            Debug.Log(destination);
            Debug.Log(agent);
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && 
            !collision.gameObject.GetComponent<MovementInput>().isCharging())
        {
            var heading = goal.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            collision.gameObject.GetComponent<PlayerHealth>().Damage(damage, direction);
        }
        else if(collision.gameObject.tag == "Player" &&
            collision.gameObject.GetComponent<MovementInput>().isCharging())
        {
            this.GetComponent<EnemyHealth>().Damage(
                collision.gameObject.GetComponent<MovementInput>().damage,
                collision.gameObject.GetComponent<MovementInput>().knockback);
        }
    }
}
