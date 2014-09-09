using UnityEngine;
using System.Collections;

public class depthCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("GameManager").GetComponent<PlayMode>().NowMode == PlayMode.Mode.Play){
			this.camera.depth = -1;
		}else if(GameObject.Find("GameManager").GetComponent<PlayMode>().NowMode == PlayMode.Mode.Play2){
			this.camera.depth = 1;
		}
	}
}
