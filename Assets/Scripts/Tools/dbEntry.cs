using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleJSON;

public class dbEntry : MonoBehaviour {

	public string prefix;
	List<string> idList; 

	// Use this for initialization
	void Start () {
		RefreshIdList ();
	}


	public string[] getIdList(){
		RefreshIdList ();
		return ListToArray(idList);
	}

	public string getJSON(string id){
		return PlayerPrefs.GetString (prefix + "_" + id);
	}

	public savestract get(string id){
		var map = JSON.Parse(PlayerPrefs.GetString (prefix + "_" + id));
		return new savestract (map ["name"].Value, map ["body"].Value, map ["id"].Value, map ["time"].Value);
	}


	public string create(savestract save){
		PlayerPrefs.SetString (prefix + "_" + save.id, save.json);
		AddId (save.id);
		Debug.Log (save);
		return save.id;
	}

	void AddId(string id){
		RefreshIdList ();
		idList.Add (id);
		string value = "[";
		foreach (string s in idList) {
			value+="\""+s+"\",";
		}
		if(idList.Count>0)value=value.Substring(0,value.Length-1);
		value+="]";
		PlayerPrefs.SetString (prefix + "_id_list", value);
	}

	void RefreshIdList(){
		string list= PlayerPrefs.GetString (prefix + "_id_list");
		if(list=="")list="[]";
		var map = JSON.Parse(list);
		JSONArray j = map.AsArray;
		idList = new List<string> ();
		foreach (JSONNode node in j) {
			idList.Add(node.Value);
		}
	}

	string[] ListToArray(List<string> a){
		string[] value = new string[a.Count];
		int i = 0;
		foreach(string str in a){
			value[i++]=str;
		} 
		return value;
	}
}

public struct savestract{
	public string n;
 	public string b;
	public string json;
	public string id;
	public string time;
	public savestract(string name,string body){
		id=DateTime.Now.ToString ()+Time.deltaTime+Time.frameCount;
		time = DateTime.Now.ToString ();
		n = name;
		b = body;
		json = "{ \"name\":\"" + name + "\"," +
				"\"body\":\"" + body + "\","+
				"\"time\":\"" + time + "\","+
				"\"id\":\"" + id + "\"}";
	}
	public savestract(string name,string body,string id,string time){
		this.id=id;
		this.time = time;
		n = name;
		b = body;
		json = "{ \"name\":\"" + name + "\"," +
				"\"body\":\"" + body + "\","+
				"\"time\":\"" + this.time + "\","+
				"\"id\":\"" + this.id + "\"}";	
	}
}