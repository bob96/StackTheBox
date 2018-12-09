using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] spawns;
    private float timeBtwSpawn;
    public float maxTimeBtwSpawn;

	
	// Update is called once per frame
	void Update () {

        int rand = Random.Range(0, spawns.Length);
        if (timeBtwSpawn <= 0)
        {
            //instantiate the gameobject
            Instantiate(spawns[rand], transform.position, Quaternion.identity);
            //set the position of the spawner in ther other side of the screen
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            // reset timer
            timeBtwSpawn = maxTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
	}
}
