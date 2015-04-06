using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleJSON;

public class WebDBSaver : MonoBehaviour {

	public string prefix;
	public string server;

	public WebIO req;
	public void Response (string json){
		Debug.Log("WWW resp: "+ json);
	}

	public void create(string name,string body){
		Dictionary<string,string> param= new Dictionary<string, string>();
		param.Add("name",name);
		param.Add("body",body);
		req.POST(server+prefix+"change_event",param);
	}
	
	public void save(string name,string body){
		Dictionary<string,string> param= new Dictionary<string, string>();
		param.Add("name",name);
		param.Add("body",body);
		req.POST(server+prefix+"change_event",param);
	}

}
