using UnityEngine;
using System.Collections;

public class CheckVelocity : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Player").transform.parent == null){ rigidbody.velocity = new Vector3(0, 0, 0); }
	}
}
