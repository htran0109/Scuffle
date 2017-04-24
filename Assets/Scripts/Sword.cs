using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    public int damage;
    public Vector3 knockback;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        knockback = transform.forward;
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit");
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage, knockback);
        }
    }
}
