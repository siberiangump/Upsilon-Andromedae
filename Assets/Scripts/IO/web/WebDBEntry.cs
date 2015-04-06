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
	void Start () {
		maps = new Dictionary<string, string>();
		req.GET(server+prefix+"getAll",this.gameObject);
	}

	public void Response (string json){
		Debug.Log("WWW resp: "+ json);
		parse(json);

	}

	public string get(string id){
		if(maps.ContainsKey(id))return maps[id];
		return "";
	}

	void parse(string json){
		var nodes = JSON.Parse(json);
		foreach(var m in nodes.Childs){
			maps.Add(m["_id"].Value,m.ToString());
		}
	} 
}
