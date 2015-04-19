using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System;
using System.Net;
using System.Net.Security;


public class GameMain : MonoBehaviour {
	
	void Start () {
		
//		if (flagCamp == null) {
//			flagCamp =this.GetComponent<EditorFlagCamp>();
//		}
//		flagCamp.mapId=PlayerPrefs.GetString (PrefsDefine.game + PrefsDefine.last_map);
//		LoadMap();
	}
	
	public void LoadMap(){
		Clean ();
		this.GetComponent<IO> ().Load ();
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
