using UnityEngine;
using System.Collections;

[RequireComponent (typeof (IO))]
[RequireComponent (typeof (MapModel))]
[RequireComponent (typeof (PlayerModel))]
public class GameMain : MonoBehaviour {
	
	MapModel map;
	IO io;
	PlayerModel player;

	private static GameMain instance;
	public static GameMain Instance{
		get{
			if(instance==null){
				instance = GameObject.FindObjectOfType<GameMain>();
				if(instance == null){
					GameObject gmo =  Instantiate(Resources.Load("prefabs/editor_prefs/MainController")) as GameObject;
					instance = gmo.GetComponent<GameMain>();
					instance.name ="MainContreller";
				}
			}
			return instance;
		}
	}

	public static GameObject testMain;

	public static GameObject ScreenOwner{
		get{
			GameObject value = Instance.FindPlayer();
			if(value == null) {

			}
			return value;
		}
	}

	void Awake(){
		map = this.GetComponent<MapModel>();
		io = this.transform.GetComponentInChildren<IO>();
		player = this.GetComponent<PlayerModel>();
		PlayerModel.ParseJSON(PlayerPrefs.GetString(PrefsDefine.player),player);
	}

	public void LoadMap(){
		io.Load (map.id);
		map.id = io.lastId;
		map.name = io.lastName;
		map.lastSave = io.lastSave;
	}

	GameObject FindPlayer(){
		GameObject needNewPlayer = null;
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject gmo in players){
			Player player = gmo.GetComponent<Player>();
			if(gmo.name == player.name){
				needNewPlayer = gmo;
			}
		}
		return needNewPlayer;
	}
}
