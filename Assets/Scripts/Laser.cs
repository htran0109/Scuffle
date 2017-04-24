using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private Material laserMat;
    float startUpTime;
    float t;
	// Use this for initialization
	void Start () {
        

        Destroy(gameObject, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<PlayerHealth>().Damage(9999, new Vector3(0, 0, 0));
            }
        }
    }
}
