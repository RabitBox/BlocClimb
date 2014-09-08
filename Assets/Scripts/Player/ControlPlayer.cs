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
		// 
		if(touch == true && jump == false) hold = true;
		if(touch == false || jump == true) hold = false;

		// 
		if(hold){
			if(Input.GetMouseButton(0) == true){
				if(this.gameObject.transform.parent == null) this.gameObject.transform.parent = gameObject.transform.FindChild("Arm").GetComponent<CheckArm>().touchParent;
			}else{
				this.gameObject.transform.parent = null;
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
		if(this.gameObject.transform.parent == null){
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
		dir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0.0f, Input.GetAxisRaw ("Vertical")).normalized;	// 入力中の角度
		rot = Mathf.Atan2 (dir.x, dir.z) * Mathf.Rad2Deg + this.transform.localEulerAngles.y;					// 入力 + 現在向いている角度
		if (rot > 360.0f) rot -= 360.0f;	if (rot < 0.0f) rot += 360.0f;										// 角度補正
		Vector3 Vec = new Vector3(0,0,0);
		SpeedSet = 1.0f;
		if (dir == new Vector3 (0.0f, 0.0f, 0.0f)) {
			if(jump) SpeedSet = 0.0f;
			else SpeedSet = 0.0f;
		}
		//Debug.Log(rigidbody.isKinematic);
		// 分岐　親がある or 親がない
		if(this.gameObject.transform.parent == null){
			// 移動
			if(jump == false) {
				Vec = new Vector3 ((float)Math.Sin (rot * Math.PI / 180) * Speed * SpeedSet, rigidbody.velocity.y, (float)Math.Cos (rot * Math.PI / 180) * Speed * SpeedSet);
				rigidbody.velocity = Vec;
			}else{
				float vx = rigidbody.velocity.x + ((float)Math.Sin (rot * Math.PI / 180) * Speed * SpeedSet) * 0.1f;
				float vz = rigidbody.velocity.z + ((float)Math.Cos (rot * Math.PI / 180) * Speed * SpeedSet) * 0.1f;
				if(Math.Abs(vx) > Speed) vx = rigidbody.velocity.x;
				if(Math.Abs(vz) > Speed) vz = rigidbody.velocity.z;
				Vec = new Vector3 (vx, rigidbody.velocity.y, vz);
				rigidbody.velocity = Vec;
			}

			// ジャンプ
			if (Input.GetButtonDown ("Jump") && jump == false){
				rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 5.0f, rigidbody.velocity.z);
				jump = true;
			}

			if(rigidbody.isKinematic == true) rigidbody.isKinematic = false;

		}else{
			Vec = new Vector3 ((float)Math.Sin (rot * Math.PI / 180) * Speed * SpeedSet, rigidbody.velocity.y, (float)Math.Cos (rot * Math.PI / 180) * Speed * SpeedSet);
			this.gameObject.transform.parent.rigidbody.velocity = Vec;
			this.gameObject.transform.rigidbody.velocity = Vec;

			//if(rigidbody.isKinematic == false) rigidbody.isKinematic = true;

		}
	}
}
