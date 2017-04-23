using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sniper : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, target.position) < 20.0f)
        {
            StartCoroutine("Attack");
        }
	}

    IEnumerator Attack()
    {
        GetComponent<MoveTo>().StopMoving();
        yield return new WaitForSeconds(3.0f);
        GetComponent<MoveTo>().StartMoving();
        yield return null;
    }
}
