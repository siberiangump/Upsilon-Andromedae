using UnityEngine;
using System.Collections;

public static class MapJSONInterface {

	public static string GetSaveString(){
		int a = 0;
		string json="";
		GameObject[] nodes =  GameObject.FindGameObjectsWithTag("space_body");
		json+= "{\"bodies\""+":[" ;
		foreach (GameObject nd in nodes)
		{
			a++;
			json+="{\"name\":\""+nd.name+"\",\"prefab\":\""+nd.GetComponent<ObjectPreview>().prefab_name+"\",\"development\":\""+nd.GetComponent<ObjectPreview>().development+"\",\"capability\":\""+nd.GetComponent<ObjectPreview>().capability+"\",\"position\":{\"x\":" + nd.transform.position.x +",\"y\":"+nd.transform.position.y+",\"z\":"+nd.transform.position.z+"}},";
		}
		if(a>0)json=json.Substring(0,json.Length-1);
		json+="],\"transitions\":[";
		a = 0;
		GameObject[] transitions =  GameObject.FindGameObjectsWithTag("transition");
		foreach (GameObject trns in transitions)
		{
			a++;
			json+="{\"name\":\""+trns.name+"\",\"from\":" + trns.GetComponent<LineHolder>().from.name+",\"to\":"+trns.GetComponent<LineHolder>().target.name+"},";
		}
		if(a>0)json=json.Substring(0,json.Length-1);
		json+="]}";
		
		return json;
	}

}
