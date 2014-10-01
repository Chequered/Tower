using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] wayPoints;

	public Vector3 GetNextWaypoint(int i){
		if(i > wayPoints.Length){
			return wayPoints[0].transform.position;
		}
		return wayPoints[i].transform.position;
	}

	private void OnDrawGizmos (){
		for(int i = 0; i < wayPoints.Length; i++)
		{
			if(i + 1 < wayPoints.Length){
				Gizmos.color = Color.green;
				Gizmos.DrawLine(wayPoints[i].transform.position, wayPoints[i + 1].transform.position);
			}
			Gizmos.DrawSphere(wayPoints[i].transform.position, 0.3f);
		}
	}
}
