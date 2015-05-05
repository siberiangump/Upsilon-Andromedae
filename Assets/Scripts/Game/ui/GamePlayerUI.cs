using UnityEngine;
using System.Collections;

public class GamePlayerUI : MonoBehaviour {

	public Player player;
	public List spaceBodyList; 

	public void Init(GameObject player){
		this.player = player.GetComponent<Player>();
		if(spaceBodyList == null){
			spaceBodyList = this.transform.GetComponentInChildren<List>();
		}
		if(Validation());
	}

	[ContextMenu ("Draw")]
	public void Draw(){
		spaceBodyList.Items = player.own;
	}

	bool Validation(){
		if (spaceBodyList == null) {
			Debug.Log("no UI list");
			return false;
		}
		if (player == null) {
			Debug.Log("no player grab from");
			return false;
		}
		return true;
	}
}
