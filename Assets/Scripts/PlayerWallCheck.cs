using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCheck : MonoBehaviour {
    public GameObject mainCamera;
    public bool foundWall = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        foundWall = false;
        Debug.DrawRay(this.gameObject.transform.position, mainCamera.gameObject.transform.position, Color.red,0.5f);
        if (Physics.Linecast(this.gameObject.transform.position, mainCamera.gameObject.transform.position, out hit))
        {
            Transform objectHit = hit.transform;
            if(objectHit.gameObject.tag == "Wall")
            {
                Debug.Log("Make wall transparent");
                objectHit.gameObject.GetComponent<Wall>().makeTransparentCounter = 0;
            }
        }
    }
}
