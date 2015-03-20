using UnityEngine;
using SimpleJSON;
using System.Collections;

public class MapJSONParser : MonoBehaviour {

	public void LoadMap(string json){
		var map = JSON.Parse(json);
		var nodes = map["bodies"]; //access object member
		
		foreach (var node in nodes.Childs){
			
			float x = node["position"]["x"].AsFloat;
			float y = node["position"]["y"].AsFloat;
			float z = node["position"]["z"].AsFloat;

			GameObject NODE=(GameObject) Instantiate(Resources.Load("Prefabs/planets"+node["prefab"].Value));
			NODE.transform.position=new Vector3(x,y,z);
			NODE.name = node["name"].Value;

		}
		
		var transitions = map["transitions"]; //access object member
		foreach (var transition in transitions.Childs){
			GameObject t = GameObject.Find(transition["from"]).GetComponent<EditorSpaceBody>().CreateConnection(transition["name"].Value);
			t.GetComponent<LineHolder>().FixTarget(GameObject.Find(transition["to"]));
		}
		
	}

}
