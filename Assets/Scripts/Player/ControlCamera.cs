using UnityEngine;
using System.Collections;

public class ControlCamera : MonoBehaviour {
	private float angle = 0.0f; 

	// Update is called once per frame
	void Update () {
		// カメラ or 視点
		float mouseY = Input.GetAxis("Mouse Y");
		angle += (-mouseY) * staticField.lookSpeed * Time.deltaTime;
		if(angle >= 45.0f) angle = 45.0f;
		if(angle <= -45.0f) angle = -45.0f;
		transform.localRotation = Quaternion.Euler(angle, 0, 0);
		//transform.Rotate (new Vector3(mouseY, 0.0f, 0.0f), staticField.lookSpeed * Time.deltaTime);
		//if (transform.localRotation.x > 45)
		//	transform.localRotation = Quaternion.Euler(45, 0, 0);
	}
}
