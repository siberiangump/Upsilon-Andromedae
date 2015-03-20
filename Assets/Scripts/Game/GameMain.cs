using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System;
using System.Net;
using System.Net.Security;


public class GameMain : MonoBehaviour {
		
	public string mapId = "";

	// Use this for initialization
	void Start () {
	
	}

	public void Load(string id){

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

}
