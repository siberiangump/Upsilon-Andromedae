
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class IO : MonoBehaviour {

	public WebDBEntry dbProxy;
	public WebDBSaver dbSaver;

	//last save data
	public string lastName;
	public string lastSave;
	public string lastId;

	void Awake(){
		if(dbProxy == null) {
			dbProxy = GameObject.Find("DBProxy").GetComponent<WebDBEntry>();
		}
	}

	public string Create(string name){
		if (name != "") {
			dbSaver.create (name, MapJSONSerializer.GetSaveString());
			lastName = name;
		}
		return "";
	}

	public void Save(){
		if (lastName != "") {
			dbSaver.create (lastName, MapJSONSerializer.GetSaveString());
		}
	}
	
	public void Save(string name){
		if (name != "") {
			dbSaver.create (name, MapJSONSerializer.GetSaveString());
			lastName = name;
		}
	}
	
	public void Load(string id){
		if(!Validation()){return;};

		Clean();
		MapJSONParser parser = this.gameObject.GetComponent<MapJSONParser> ();
		if (parser == null) {
			parser = this.gameObject.AddComponent<MapJSONParser> ();
		}
		string save = dbProxy.get (id);
		var m = JSON.Parse(save);
		lastName = m["name"].Value;
		lastSave = m["update"].Value;
		lastId = id;
		parser.LoadMap (m["body"].Value);
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

	public bool Validation(){
		if(dbProxy == null){
			return false;
		}
		return true;
	}
}
