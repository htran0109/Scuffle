using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndScene1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Changing to level 2");
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
