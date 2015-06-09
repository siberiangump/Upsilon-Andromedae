using UnityEngine;
using System.Collections;

[RequireComponent (typeof (IO))]
[RequireComponent (typeof (MapModel))]
[RequireComponent (typeof (PlayerModel))]
public class GameMain : Singleton<GameMain> {
	
	MapModel map;
	IO io;
	PlayerModel player;

	public static GameObject testMain;

	public static GameObject ScreenOwner{
		get{
			GameObject value = Instance.FindPlayer();
			if(value == null) {

			}
			return value;
		}
	}

	protected override void OnSingletonAwake(){
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
