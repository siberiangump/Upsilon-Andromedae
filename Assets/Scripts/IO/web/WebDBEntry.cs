using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleJSON;

public class WebDBEntry : MonoBehaviour {

	public string prefix;
	public string server;

	public Dictionary<string, string> maps;

	public WebIO req;
	void Awake () {
		if(GameObject.FindGameObjectWithTag("MainController")){
			if(this.transform.parent.tag!="MainController"){
				Destroy(this.gameObject);
				return;
			}
		}
		this.name = "DBProxy";
		maps = new Dictionary<string, string>();
		req.GET(server+prefix+"getAll",this.gameObject);
	}

	public void Response (string json){
		Debug.Log("WWW resp: "+ json);
		PlayerPrefs.SetString("maps backup",json);
		parse(json);

	}

	public string get(string id){
		string value = "";
		if(maps.Count==0){
			parse(PlayerPrefs.GetString("maps backup"));
		}
		if(maps.ContainsKey(id))value = maps[id];
		return value;
	}

	void parse(string json){
		var nodes = JSON.Parse(json);
		foreach(var m in nodes.Childs){
			maps.Add(m["_id"].Value,m.ToString());
		}
	} 
}
