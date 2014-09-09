using UnityEngine;
using System.Collections;

public class GoalCheck : MonoBehaviour {
	public GameObject c;
	private void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			GameObject.Find("GameManager").GetComponent<GameManager>().clearFlg = true;
			Instantiate(c);
		}
	}
}
