using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {


    public int makeTransparentCounter = 3;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(makeTransparentCounter <= 2)
        {
            Debug.Log("Transparent wall here");
            this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, .2f);
        }
        else
        {
            this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1f);
        }

        makeTransparentCounter++;
    }

}
