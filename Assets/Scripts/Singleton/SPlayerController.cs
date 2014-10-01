using UnityEngine;
using System.Collections;

public class SPlayerController : MonoBehaviour {

	protected Vector3 pos;
	protected LineRenderer line;

	public void StartTrail(){
		gameObject.AddComponent<LineRenderer>();
		line = GetComponent<LineRenderer>();
		line.SetColors(Color.blue, Color.red);
	}

	public void StopTrail(){
		Destroy(line);
	}

	public virtual void Update(){
		transform.position = pos;
		if(line != null){
			line.SetPosition(0, pos);
		}
	}
}
