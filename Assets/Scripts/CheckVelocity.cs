using UnityEngine;
using System.Collections;

public class CheckVelocity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.velocity = new Vector3(3, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//rigidbody.velocity = new Vector3(30, 0, 0);
		Debug.Log(rigidbody.velocity);
	}
}
