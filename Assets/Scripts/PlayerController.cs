using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerController : MonoBehaviour {
	public List<GameObject> enemiesInRange = new List<GameObject>();
	private GameObject currentTarget;
	private float shotCooldown;
	public GameObject bulletPrefab;
	public bool canShoot;
	
	private void Update(){
		if(enemiesInRange.Count > 0){
			foreach(GameObject enem in enemiesInRange){
				if(enem == null){
					enemiesInRange.Remove(enem);
				}
			}
			Attack(enemiesInRange[0]);
		}
	}
	
	private void Shoot(){
		shotCooldown = 8;
		GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
	}
	
	private void OnTriggerEnter(Collider coll){
		if(coll.tag == "Enemy"){
			enemiesInRange.Add(coll.gameObject);
			enemiesInRange = enemiesInRange.OrderBy(enemy => enemy.GetComponent<EnemyController>().Priority).ToList();
		}
	}
	
	private void OnTriggerExit(Collider coll){
		if(coll.tag == "Enemy"){
			enemiesInRange.Remove(coll.gameObject);
			enemiesInRange = enemiesInRange.OrderBy(enemy => enemy.GetComponent<EnemyController>().Priority).ToList();
		}
	}
	
	private void Attack(GameObject enem){
		if(canShoot){
			Vector3 relativePos = enem.transform.position - transform.position;
			Quaternion enemyLookAt = Quaternion.LookRotation(relativePos);
			this.transform.rotation = Quaternion.Slerp(transform.rotation, enemyLookAt, Time.deltaTime * 10f);
			if(shotCooldown > 0){
				shotCooldown -= 0.25f;
			}else{
				Shoot();
			}
		}
	}
	
}
