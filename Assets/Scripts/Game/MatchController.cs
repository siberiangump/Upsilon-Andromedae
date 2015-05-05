using UnityEngine;
using System.Collections;

public class MatchController : MonoBehaviour {
	 
	public GameObject mainUI;
	public IO io;
	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("MainController") == null){return;}
		Init ();
	}

	[ContextMenu ("init")]
	void Init () {
		io.Load(PlayerPrefs.GetString(PrefsDefine.game + PrefsDefine.current_map));
		GameObject ui = GameObject.Find("Canvas") as GameObject;

		if(mainUI){
			mainUI.BroadcastMessage("GameLoaded",SendMessageOptions.DontRequireReceiver);
		}else{
			Debug.Log("define game ui canvas",this.gameObject);
		}
	}
}
