using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


    public EnemyStats stats;
    public int currHealth;

    // Use this for initialization
    void Start() {
        currHealth = stats.health;
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.GetComponent<MoveTo>().agent.enabled == false &&
            gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 1) {
            gameObject.GetComponent<MoveTo>().agent.enabled = true;

        }
    }

    public void Damage(int dmg, Vector3 knockback)
    {

        currHealth -= dmg;
        if (currHealth < 0)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<>().agent.enabled = false;
        this.gameObject.GetComponent<Rigidbody>().AddForce(4000 * (knockback + new Vector3(0, 1, 0)));
       
    }
}
