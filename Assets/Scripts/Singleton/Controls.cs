using UnityEngine;
using System.Collections;

public class Controls : SPlayerController {



	public override void Update(){
		base.Update();
		if(Input.GetKey(KeyCode.A)){
			pos.x -= 0.2f;
		}
		if(Input.GetKey(KeyCode.D)){
			pos.x += 0.2f;
		}
		if(Input.GetKey(KeyCode.W)){
			pos.z += 0.2f;
		}
		if(Input.GetKey(KeyCode.S)){
			pos.z -= 0.2f;
		}
		if(Input.GetKeyUp(KeyCode.E)){
			StartTrail();
		}
		if(Input.GetKeyUp(KeyCode.R)){
			StopTrail();
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			Score.singleton.AddScore(2);
		}
	}
}
