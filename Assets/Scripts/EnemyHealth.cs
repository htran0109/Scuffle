using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


    public EnemyStats stats;
    public int currHealth;

	// Use this for initialization
	void Start () {
        currHealth = stats.health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int dmg, Vector3 knockback)
    {
        currHealth -= dmg;
        this.gameObject.GetComponent<Rigidbody>().AddForce(130 * (knockback + new Vector3(0, 1, 0)));
    }
}
