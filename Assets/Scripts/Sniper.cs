using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sniper : MonoBehaviour {

    public Transform targetLocation;
    public Transform target;
    public GameObject laser;

    public float coolDown = 6.0f;
    public float timer = 6.0f;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
    }




	
	// Update is called once per frame
	void Update () {
		if(timer < 0 && Vector3.Distance(transform.position, target.position) < 20.0f)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, target.position - transform.position, out hit, 100.0f))
            {
                if(hit.collider.gameObject.tag == "Player")
                {
                    timer = coolDown;
                    StartCoroutine("Attack");
                }
            }
            
        }
        if(timer < 0)
        {
            timer = 0;
        }
        timer -= Time.deltaTime;
	}

    IEnumerator Attack()
    {
        GetComponent<MoveToRanged>().StopMoving();
        GameObject laserGO = Instantiate(laser, transform.position, Quaternion.LookRotation(target.position - transform.position, new Vector3(0, 1, 0)));
        yield return new WaitForSeconds(1.0f);
        GetComponent<MoveToRanged>().StartMoving();
        yield return null;
    }
}
