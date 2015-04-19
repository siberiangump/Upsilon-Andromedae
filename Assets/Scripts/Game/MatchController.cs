using UnityEngine;
using System.Collections;

public class MatchController : MonoBehaviour {
	 
	public IO io;
	// Use this for initialization
	void Start () {
		io.Load(PlayerPrefs.GetString(PrefsDefine.game + PrefsDefine.current_map));
		GameObject ui = GameObject.Find("Canvas") as GameObject;
		if(ui){
			ui.BroadcastMessage("GameLoaded");
		}
	}

}
