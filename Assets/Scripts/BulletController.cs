using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public int speed;
	public int damage;
	private Vector3 target;
	
	private void Start(){
		Destroy(this.gameObject, 2f);
	}

	private void Update(){
		this.transform.position += transform.forward * speed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider coll){
		if(coll.tag == "Enemy"){
			coll.GetComponent<EnemyController>().TakeDamage(damage, this.gameObject);
		}
		Destroy(this.gameObject);
	}
}
