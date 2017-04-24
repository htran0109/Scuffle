using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int currHealth = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int dmg, Vector3 knockback)
    {
        currHealth -= dmg;

        if(currHealth < 0)
        {
            Debug.Log("DED");
        }
    }
}
