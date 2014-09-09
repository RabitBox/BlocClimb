using UnityEngine;
using System;
using System.Collections;

public class PlayMode : MonoBehaviour {
	public enum Mode : int {
		Wait,
		Play,
		Play2,
		Clear,
	}
	public Mode NowMode;

	// Use this for initialization
	void Start () {
		NowMode = Mode.Wait;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)){
			if(NowMode == Mode.Wait){
				NowMode = Mode.Play;
			}
		}
	}
}
