using UnityEngine;
using System.Collections;

public static class MapJSONSerializer{

	public static string GetSaveString(){
		int a = 0;
		string json="";
		GameObject[] nodes =  GameObject.FindGameObjectsWithTag("space_body");
		json+= "{\"bodies\""+":[" ;
		foreach (GameObject nd in nodes)
		{
//			SpaceBodyModel s = nd.GetComponent<SpaceBodyModel>();
			a++;
			json+="{\"name\":\""+nd.name+"\"," +
				"\"prefab\":\""+nd.GetComponent<SpaceBodyModel>().prefab_name+"\"," +
				"\"development\":\""+nd.GetComponent<SpaceBodyModel>().development+"\"," +
				"\"capability\":\""+nd.GetComponent<SpaceBodyModel>().capability+"\"," +
				"\"playerId\":\""+nd.GetComponent<SpaceBodyModel>().playerId+"\"," +
				"\"position\":{\"x\":" + nd.transform.position.x +"," +
							  "\"y\":"+nd.transform.position.y+"," +
							  "\"z\":"+nd.transform.position.z+"}},";
		}
		if(a>0)json=json.Substring(0,json.Length-1);
		json+="],\"transitions\":[";
		a = 0;
		GameObject[] transitions =  GameObject.FindGameObjectsWithTag("transition");
		foreach (GameObject trns in transitions)
		{
			a++;
			json+="{\"name\":\""+trns.name+"\",\"from\":" + trns.GetComponent<DrawLine>().from.name+",\"to\":"+trns.GetComponent<DrawLine>().to.name+"},";
		}
		if(a>0)json=json.Substring(0,json.Length-1);
		json+="]}";
		
		return json;
	}

}
