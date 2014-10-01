using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
		
	private float spawnCooldown;
	public GameObject[] enemyPrefab;
	
	void Update () {
		if(spawnCooldown > 0){
			spawnCooldown -= 0.1f;
		}else{
			GameObject.Instantiate(enemyPrefab[Random.Range(0,3)], transform.position, Quaternion.identity);
			spawnCooldown = 10;
		}
	}
}
