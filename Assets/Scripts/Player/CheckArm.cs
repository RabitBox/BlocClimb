using UnityEngine;
using System.Collections;

public class CheckArm : MonoBehaviour {
	public GameObject touchParent = null;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Box") {
			GameObject.Find("Player").GetComponent<ControlPlayer>().touch = true;
			touchParent = other.gameObject.transform.parent.gameObject;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		GameObject.Find("Player").GetComponent<ControlPlayer>().touch = false;
		touchParent = null;
	}
}
