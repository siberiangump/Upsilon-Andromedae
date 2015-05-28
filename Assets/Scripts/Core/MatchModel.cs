using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatchModel : MonoBehaviour {

	public string mapId; 
	public MapModel map; 

	public PlayerModel[] players;

	void Start(){
		map = this.GetComponent<MapModel>();
		if(map==null){
			map = this.gameObject.AddComponent<MapModel>();
		}
		IO.Instance.GetMapData(mapId,map);
		players = new PlayerModel[2];
	}

	public void AddPlayer(PlayerModel player){
		if(PlayerIndex(player)!=-1){
			return;
		}
		for(int i=0;i<players.Length-1;i++){
			if(players[i] == null){
				PlayerModel pm = this.gameObject.AddComponent<PlayerModel>();  
				PlayerModel.Clone(player,pm);
				players[i] = pm;
				return;
			}
		}
	}

	private int PlayerIndex(PlayerModel player){
		int value = -1;
		for(int i=0;i<players.Length-1;i++){
			if(players[i]!=null && players[i].name == player.name){
				return i;
			}
		}
		return value;
	}

}
