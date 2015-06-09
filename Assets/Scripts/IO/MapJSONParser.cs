using UnityEngine;
using SimpleJSON;
using System.Collections;

public class MapJSONParser : MonoBehaviour {

	public pars_type type;
	
	public GameObject linePrefab;

	public GameObject mapHolder;
	
	public GameObject[] SpawnChilds;

	public void LoadMap(string json){
		var map = JSON.Parse(json);
		var nodes = map["bodies"]; //access object member
		if(mapHolder==null){
			mapHolder = new GameObject();
			mapHolder.transform.position = Vector3.zero; 
			mapHolder.name = "Map";
		}

		foreach (var node in nodes.Childs){
			
			float x = node["position"]["x"].AsFloat;
			float y = node["position"]["y"].AsFloat;
			float z = node["position"]["z"].AsFloat;

			GameObject body=(GameObject) Instantiate(Resources.Load("Prefabs/planets/"+node["prefab"].Value));
			body.transform.position=new Vector3(x,y,z);
			body.transform.parent = mapHolder.transform;
			body.name = node["name"].Value;
			SpaceBodyModel bodyModel = body.GetComponent<SpaceBodyModel>();
			bodyModel.capability = node["capability"].AsInt;
			bodyModel.development = node["development"].AsInt;
			bodyModel.playerId = node["playerId"].AsInt;

			if(type == pars_type.game) {
				GameSpaceBody bodyGame = body.AddComponent<GameSpaceBody>();
				if(bodyModel.playerId!=0){
					if(PlayerAreExist(bodyModel.playerId)){
						GameObject player = new GameObject();
						player.tag = "Player";
						PlayerModel pm = player.AddComponent<PlayerModel>();					
						PlayerModel.Clone(MatchController.Instance.model.players[bodyModel.playerId-1],pm);
						player.name = pm.name;
						Player p = player.AddComponent<Player>();
						p.playerId = bodyModel.playerId;
						p.Init();
						bodyGame.InitOwner(p.gameObject);
					}else {
						GameObject p=FindPlayer(bodyModel.playerId);
						if(p!=null){
							bodyGame.InitOwner(p);
						}else{
							Debug.Log("player"+bodyModel.playerId+" can't be found");
						} 
					}
				}
			}

			foreach (GameObject c in SpawnChilds) {
				GameObject g = Instantiate (c,body.transform.position,Quaternion.identity)as GameObject;
				g.transform.parent = body.transform;
				g.GetComponent<RectTransform>().Rotate(0,180,0);
			}

		}
		
		var transitions = map["transitions"]; //access object member
		foreach (var transition in transitions.Childs){
			GameObject f =GameObject.Find(transition["from"]);
			GameObject t =GameObject.Find(transition["to"]);
			GameObject l = Instantiate(linePrefab,f.transform.position,Quaternion.identity) as GameObject;
			l.transform.parent = mapHolder.transform;
			l.GetComponent<DrawLine>().Init(new LineParametrData(f.transform,t.transform));

		}
		
	}

	bool PlayerAreExist(int playerId){
		bool needNewPlayer = true;
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject gmo in players){
			Player player = gmo.GetComponent<Player>();
			if(player && player.playerId == playerId){
				needNewPlayer = false;
			}
		}
		return needNewPlayer;
	}

	GameObject FindPlayer (int playerId){
		GameObject needNewPlayer = null;
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject gmo in players){
			Player player = gmo.GetComponent<Player>();
			if(player != null && player.playerId == playerId){
				needNewPlayer = gmo;
			}
		}
		return needNewPlayer;
	}

	public enum pars_type {game,editor};
}


