using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System;
using System.Net;
using System.Net.Security;


public class EditorMain : MonoBehaviour {

//	private save saver;

	public string mapName = "test";
	public string mapUpdate = "test";
	public string mapId = "";

	private string prefix = "editor";

	// Use this for initialization
	void Start () {
//		saver = this.GetComponent<save> ();
		mapId=PlayerPrefs.GetString (PrefsDefine.editor + PrefsDefine.last_map);
		if (mapId == ""){
			New ();
		}
	}
		                      
	public void New(){
		mapName = "not saved";
		mapUpdate = "tomorrow";
		mapId = "";
	} 

	public void Load(int id){

//		LoadMap(saver.pullSaveBodyById(id));
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

	public void LoadMap(string json){
		Clean ();

		var map = JSON.Parse(json);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
