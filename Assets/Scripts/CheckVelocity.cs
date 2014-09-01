using UnityEngine;
using System.Collections;

public class CheckVelocity : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Player").transform.parent == null){ 
			rigidbody.isKinematic = true;
		}
		if(GameObject.Find("Player").transform.parent == this.gameObject.transform) rigidbody.isKinematic = false;
	}
}
