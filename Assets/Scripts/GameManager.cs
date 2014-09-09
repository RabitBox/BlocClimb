using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public bool clearFlg = false;
	// Update is called once per frame
	void Update () {
		// クリア確認
		if(clearFlg && this.gameObject.GetComponent<PlayMode>().NowMode != PlayMode.Mode.Clear){
			this.gameObject.GetComponent<PlayMode>().NowMode = PlayMode.Mode.Clear;
		}

		// マウスを描画しない
		// マウスを画面内に固定
		if(this.gameObject.GetComponent<PlayMode>().NowMode != PlayMode.Mode.Clear){
			Screen.showCursor = false;
			Screen.lockCursor = true;
		}else if(this.gameObject.GetComponent<PlayMode>().NowMode == PlayMode.Mode.Clear){
			Screen.showCursor = true;
			Screen.lockCursor = false;
		}
	}
}
