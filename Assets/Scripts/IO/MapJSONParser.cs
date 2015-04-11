using UnityEngine;
using SimpleJSON;
using System.Collections;

public class MapJSONParser : MonoBehaviour {

	public EditorFlagCamp flagCamp;

	public GameObject linePrefab;

	public Component[] SpawnComponents;
	public GameObject[] SpawnChilds;

	public void LoadMap(string json){
		var map = JSON.Parse(json);
		var nodes = map["bodies"]; //access object member
		
		foreach (var node in nodes.Childs){
			
			float x = node["position"]["x"].AsFloat;
			float y = node["position"]["y"].AsFloat;
			float z = node["position"]["z"].AsFloat;

			GameObject NODE=(GameObject) Instantiate(Resources.Load("Prefabs/planets/"+node["prefab"].Value));
			NODE.transform.position=new Vector3(x,y,z);
			NODE.name = node["name"].Value;
			NODE.GetComponent<ObjectPreview>().capability = node["capability"].AsInt;
			NODE.GetComponent<ObjectPreview>().development = node["development"].AsInt;
			NODE.GetComponent<ObjectPreview>().playerId = node["playerId"].AsInt;

			foreach (GameObject c in SpawnChilds) {
				GameObject g = Instantiate (c,NODE.transform.position,Quaternion.identity)as GameObject;
				g.transform.parent = NODE.transform;
				g.GetComponent<RectTransform>().Rotate(0,180,0);
			}

		}
		
		var transitions = map["transitions"]; //access object member
		foreach (var transition in transitions.Childs){
			GameObject f =GameObject.Find(transition["from"]);
			GameObject t =GameObject.Find(transition["to"]);
			GameObject l = Instantiate(linePrefab,f.transform.position,Quaternion.identity) as GameObject;
			l.GetComponent<drawLine>().Init(new LineParametrData(f.transform,t.transform));
		}
		
	}

}
