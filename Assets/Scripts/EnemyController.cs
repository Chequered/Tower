using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float movementSpeed;
	public int priority;
	private int currentWaypoint;
	private int health = 100;
	private Vector3 currentWaypointPos;
	private GameObject gameController;

	private void Start(){
		gameController = GameObject.FindGameObjectWithTag("GameController");
		currentWaypointPos = gameController.GetComponent<GameController>().GetNextWaypoint(currentWaypoint);
	}

	private void Update(){
		this.transform.position = Vector3.MoveTowards(transform.position, currentWaypointPos, movementSpeed * Time.deltaTime);
		if(transform.position == currentWaypointPos){
			UpdateWaypoint();
		}
	}

	private void UpdateWaypoint(){
		currentWaypoint++;
		currentWaypointPos = gameController.GetComponent<GameController>().GetNextWaypoint(currentWaypoint);
	}

	public int Priority {
		get {
			return priority;
		}
		set {
			priority = value;
		}
	}

	public int hp(){
		return  health;
	}

	public void TakeDamage(int dmg, GameObject bullet){
		health -= dmg;
		if(health <= 0){
			Destroy(this.gameObject);
			Destroy(bullet);
		}
	}
}
