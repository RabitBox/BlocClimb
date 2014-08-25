using UnityEngine;
using System.Collections;

public class CheckFoot : MonoBehaviour {
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Box") {
			GameObject.Find("Player").GetComponent<ControlPlayer>().jump = false;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		GameObject.Find("Player").GetComponent<ControlPlayer>().jump = true;
	}
}
