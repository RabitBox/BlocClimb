using UnityEngine;
using System;
using System.Collections;

public class ControlPlayer : MonoBehaviour {
	public float Speed;
	//public float mSpeed;

	// Update is called once per frame
	void Update () {
		// カメラ or 視点
		float mouseX = Input.GetAxis("Mouse X");
		transform.Rotate (new Vector3(0.0f, mouseX, 0.0f), staticField.lookSpeed * Time.deltaTime);

		// 移動
		Move ();
	}

	// 移動
	public void Move(){
		// 入力中の角度
		Vector3 dir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0.0f, Input.GetAxisRaw ("Vertical")).normalized;
		float rot = Mathf.Atan2 (dir.x, dir.z) * Mathf.Rad2Deg + this.transform.localEulerAngles.y;
		if (rot > 360.0f) rot -= 360.0f;
		if (rot < 0.0f)	rot += 360.0f;
		if(dir != new Vector3(0.0f, 0.0f, 0.0f)){
			Vector3 Vec = new Vector3 ((float)Math.Sin (rot * Math.PI / 180) * Speed,
			                           rigidbody.velocity.y,
			                           (float)Math.Cos (rot * Math.PI / 180) * Speed);
			rigidbody.velocity = Vec;
		}
	}
}
