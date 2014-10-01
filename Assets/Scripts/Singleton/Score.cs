using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static Score singleton;
	public int score;

	private void Awake(){
		singleton = this;
	}

	public void AddScore(int _count){
		score += _count;
		guiText.text = "Score= " + score;
	}
}
