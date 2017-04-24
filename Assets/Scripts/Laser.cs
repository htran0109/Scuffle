using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private Material laserMat;
    float startUpTime;
    float t;
	// Use this for initialization
	void Start () {
        laserMat = GetComponentInChildren<MeshRenderer>().material;
        StartCoroutine("Shoot");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Shoot()
    {
        for(int i = 0; i < 10; i++)
        {
            Color newColor = laserMat.color;
            newColor.a = (0.0f / (float)i) * 128.0f;
            laserMat.color = newColor;
            yield return new WaitForSeconds(startUpTime / 10);
        }
    }
}
