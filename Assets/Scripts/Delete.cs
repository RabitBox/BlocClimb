using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("GameManager").GetComponent<PlayMode>().NowMode != PlayMode.Mode.Wait){
			Destroy(this.gameObject);
		}
	}
}
