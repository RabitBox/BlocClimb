using UnityEngine;
using System.Collections;

public class CheckArm : MonoBehaviour {
	public bool touch = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Box") {
			touch = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		touch = false;
	}
}
