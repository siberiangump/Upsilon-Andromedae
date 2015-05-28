using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerModel))]
public class Player : MonoBehaviour {

	public PlayerModel model;
	public int playerId;
	public GameObject[] own;
		
	void Start(){
		//model = this.GetComponent<PlayerModel>();
	}

	public void Init(){
		model = this.GetComponent<PlayerModel>();
		own = new GameObject[0];
	}

	public void СonquerSpaceBody(GameObject body){
		GameObject[] array = null;
		ArrayTool.Add(own,out array,body);
		own = array;
	}

	public void LeaveSpaceBody(GameObject body){
		GameObject[] array = null;
		ArrayTool.Remove(own,out array,body);
		own = array;
	}
	
}
