using UnityEngine;
using System;
using System.Collections;

public class ControlPlayer : MonoBehaviour {
	public float Speed;
	private Vector3 dir;
	private float rot;
	private float angle = 0.0f;
	private bool jump = false;	// ジャンプ中ならば true
	private bool hold = false;	// ホールド中ならば true

	// Update is called once per frame
	void Update () {
		Look ();
		Move ();
	}

	// 視点
	private void Look(){
		// カメラ or 視点
		if(hold != true){
			float mouseX = Input.GetAxis("Mouse X");
			angle += mouseX * staticField.lookSpeed * Time.deltaTime;
			if(angle > 360.0f) angle -= 360.0f;
			if(angle < 0.0f) angle += 360.0f;
			transform.localRotation = Quaternion.Euler(0, angle, 0);
		}
	}

	// 移動
	private void Move(){
		// 入力中の角度
		if (jump == false) {
			dir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0.0f, Input.GetAxisRaw ("Vertical")).normalized;
			rot = Mathf.Atan2 (dir.x, dir.z) * Mathf.Rad2Deg + this.transform.localEulerAngles.y;
		}
		if (rot > 360.0f) rot -= 360.0f;
		if (rot < 0.0f) rot += 360.0f;
		float _a = 1.0f;
		if (dir == new Vector3 (0.0f, 0.0f, 0.0f)) {
			if(jump) _a = 0.0f;
			else _a = 0.0f;
		}
		Vector3 Vec = new Vector3 ((float)Math.Sin (rot * Math.PI / 180) * Speed * _a, rigidbody.velocity.y, (float)Math.Cos (rot * Math.PI / 180) * Speed * _a);
			rigidbody.velocity = Vec;
	
		if (Input.GetButtonDown ("Jump") && jump == false){
			rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 3.0f, rigidbody.velocity.z);
			jump = true;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		jump = false;
	}
}
