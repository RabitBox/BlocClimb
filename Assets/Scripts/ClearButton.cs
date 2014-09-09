using UnityEngine;
using System.Collections;

public class ClearButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*if ( GUI.Button( Rect(Screen.width/2 - 100, Screen.height/2 - 200, 100, 20), "Title" ) )
		{
			Application.LoadLevel("title");
		}//*/
	}

	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 + 30, 100, 20), "Continue")) Application.LoadLevel("Stage1");
		if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 + 60, 100, 20), "Title")) Application.LoadLevel("title");
	}
}
