using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


    public Vector3[] spawnLocations;
    public Object enemyPrefab;
    private bool spawned = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (!spawned && collision.gameObject.tag != "Weapon")
        {
            for (int i = 0; i < spawnLocations.Length; i++)
            {
                Instantiate(enemyPrefab, spawnLocations[i], Quaternion.identity);
            }
            DestroyObject(this.gameObject);
            Destroy(this);
            spawned = true;
        }

    }
}

