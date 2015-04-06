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
		Clean ();
		this.GetComponent<IO> ().Load ();
	}

	public void New(){
		flagCamp.mapName = "not saved";
		flagCamp.lastSave = "tomorrow";
		flagCamp.mapId = this.GetComponent<IO> ().Create (flagCamp.mapName);
		PlayerPrefs.SetString (PrefsDefine.editor + PrefsDefine.last_map,flagCamp.mapId);
	} 
	
	public void Clean(){

		GameObject[] fan =  GameObject.FindGameObjectsWithTag("space_body");
		foreach (GameObject nd in fan) {
			DestroyImmediate(nd);
		}

		GameObject[] transitions =  GameObject.FindGameObjectsWithTag("transition");
		foreach (GameObject trns in transitions) {
			DestroyImmediate(trns);	
		}

	}


	// Update is called once per frame
	void Update () {
	
	}
}
