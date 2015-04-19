using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class IO : MonoBehaviour {

	public EditorFlagCamp main=null;
	public WebDBEntry dbProxy;
	public WebDBSaver dbSaver;
	public InputField save_name;


	void Awake(){
		main = GameObject.FindGameObjectWithTag ("GameController").GetComponent<EditorFlagCamp> ();
		if(dbProxy == null) {
			dbProxy = GameObject.Find("DBProxy").GetComponent<WebDBEntry>();
		}
	}

	public string Create(string name){
		if (!main) return "";
		save_name.text = main.mapName;
		if (name != "") {
			dbSaver.create (save_name.text, MapJSONSerializer.GetSaveString());
		}
		return "";
	}

	public void Save(){
		if (!main) return;

		if (save_name.text != "") {
			main.mapName = save_name.text;
			//main.lastSave = System.DateTime.Now.ToString();
			dbSaver.create (save_name.text, MapJSONSerializer.GetSaveString());
		}
	}

	[ContextMenu ("Load")]
	public void Load(){
		if(!Validation()){return;};

		Clean();
		MapJSONParser parser = this.gameObject.GetComponent<MapJSONParser> ();
		if (parser == null) {
			parser = this.gameObject.AddComponent<MapJSONParser> ();
		}
		string save = dbProxy.get (main.mapId);
		var m = JSON.Parse(save);
		main.mapName = m["name"].Value;
		if(save_name){save_name.text = m["name"].Value;}
		main.lastSave = m["update"].Value;
		parser.LoadMap (m["body"].Value);
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
		main.mapName = m["name"].Value;
		if(save_name){save_name.text = m["name"].Value;}
		main.lastSave = m["update"].Value;
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
