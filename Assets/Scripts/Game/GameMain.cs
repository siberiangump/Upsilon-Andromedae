using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MapModel))]
[RequireComponent (typeof (IO))]
public class GameMain : MonoBehaviour {

	MapModel map;
	IO io;

	void Start(){
		map = this.GetComponent<MapModel>();
		io = this.GetComponent<IO>();
	}

	public void LoadMap(){
		io.Load (map.id);
		map.id = io.lastId;
		map.name = io.lastName;
		map.lastSave = io.lastSave;
	}

}
