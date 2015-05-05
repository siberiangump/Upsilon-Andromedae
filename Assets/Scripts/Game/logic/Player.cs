using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerModel))]
public class Player : MonoBehaviour {

	public PlayerModel model;
	public int playerId;
	public GameObject[] own;
		
	void Start(){
		model = this.GetComponent<PlayerModel>();
	}

}
