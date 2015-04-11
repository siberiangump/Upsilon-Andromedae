using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System;
using System.Net;
using System.Net.Security;


public class EditorMain : MonoBehaviour {

//	private save saver;
	EditorFlagCamp flagCamp ;


	private string prefix = "editor";

	// Use this for initialization
	void Start () {

		if (flagCamp == null) {
			flagCamp =this.GetComponent<EditorFlagCamp>();
		}
//		flagCamp.mapId=PlayerPrefs.GetString (PrefsDefine.editor + PrefsDefine.last_map);
//		if (flagCamp.mapId == "") {
//			New ();
//		} else {
//			LoadMap();
//		}
	}
		
	public void LoadMap(){
		this.GetComponent<IO> ().Load ();
	}

	public void New(){
		flagCamp.mapName = "not saved";
		flagCamp.lastSave = "tomorrow";
		flagCamp.mapId = this.GetComponent<IO> ().Create (flagCamp.mapName);
		PlayerPrefs.SetString (PrefsDefine.editor + PrefsDefine.last_map,flagCamp.mapId);
	} 
	



	// Update is called once per frame
	void Update () {
	
	}
}
