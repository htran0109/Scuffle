using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {


    public EnemyStats stats;
    public int currHealth;
    public float hitStun;

    // Use this for initialization
    void Start() {
        currHealth = stats.health;
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.GetComponent<NavMeshAgent>().enabled == false &&
            hitStun > 2f) {
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            gameObject.GetComponent<NavMeshAgent>().enabled = true;

        }
        hitStun += Time.deltaTime;
    }

    public void Damage(int dmg, Vector3 knockback)
    {

        currHealth -= dmg;
        if (currHealth < 0)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        this.gameObject.GetComponent<Rigidbody>().AddForce(150 * (knockback + new Vector3(0, 2, 0)));
        hitStun = 0;
        

    }
}
