using UnityEngine;
using System;
using System.Collections;

public class ControlPlayer : MonoBehaviour {
	public float Speed;
	private Vector3 dir;
	private float rot;
	private float angle = 0.0f;
	public bool jump = false;	// ジャンプ中ならば true
	public bool touch = false;
	private bool hold = false;	// ホールド中ならば true
	private float SpeedSet = 1.0f;

	// Update is called once per frame
	void Update () {
		Look ();
		Hold ();
		Move ();
	}

	//------------------------------
	// 掴み
	private void Hold(){
		if(touch == true && jump == false) {
			hold = true;
		}
		if(touch == false || jump == true) hold = false;

		if(hold){
			if(this.gameObject.transform.parent == null){
				this.gameObject.transform.parent = gameObject.transform.FindChild("Arm").GetComponent<CheckArm>().touchParent;
			}
		}
		else{
			this.gameObject.transform.parent = null;
		}
	}

	//------------------------------
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

	//------------------------------
	// 移動
	private void Move(){
		// 入力中の角度
		if (jump == false) {
			dir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0.0f, Input.GetAxisRaw ("Vertical")).normalized;
			rot = Mathf.Atan2 (dir.x, dir.z) * Mathf.Rad2Deg + this.transform.localEulerAngles.y;
		}
		if (rot > 360.0f) rot -= 360.0f;
		if (rot < 0.0f) rot += 360.0f;
		SpeedSet = 1.0f;
		if (dir == new Vector3 (0.0f, 0.0f, 0.0f)) {
			if(jump) SpeedSet = 0.0f;
			else SpeedSet = 0.0f;
		}
		Vector3 Vec = new Vector3 ((float)Math.Sin (rot * Math.PI / 180) * Speed * SpeedSet, rigidbody.velocity.y, (float)Math.Cos (rot * Math.PI / 180) * Speed * SpeedSet);
			rigidbody.velocity = Vec;
	
		if (Input.GetButtonDown ("Jump") && jump == false){
			rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 2.0f, rigidbody.velocity.z);
			jump = true;
		}
	}
	/*private void OnCollisionStay(Collision other){
		//if(jump) {if(other.transform.tag == "Box")SpeedSet = 0;}
		//else {if(other.transform.tag == "Box")SpeedSet = 1;}
	}//*/
}
