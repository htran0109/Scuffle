using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float arrowSpeed;
    public int damage;
    public Vector3 knockback;

    Vector3 unitDir;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        unitDir = this.transform.up;
    }
	
	// Update is called once per frame
	void Update () {
        
        rb.velocity = unitDir * arrowSpeed;
        knockback = transform.forward;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit");
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage, knockback);
            DestroyObject(this.gameObject);
        }
    }
}
