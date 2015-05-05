using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpaceBodyModel))]
public class GameSpaceBody : MonoBehaviour {

	public int units = 0; 
	public GameObject UI;
	public PlayerModel owner = null; 
	public float cooldown;
	
	SpaceBodyModel model;

	// Use this for initialization
	void Awake () {

		model = this.GetComponent<SpaceBodyModel> ();
		if(owner){
			cooldown = Config.haveOwnerSpaceBodyCounterCooldown;
			model.color = owner.color;
		}else cooldown = Config.noOwnerSpaceBodyCounterCooldown;

	}

	// Update is called once per frame
	void Update () {
		Gainer ();
	}

	void InitOwner(GameObject player){
		owner = player.GetComponent<PlayerModel>();
		model.color = owner.color;

	}

	void Gainer () {
		cooldown -= Time.deltaTime;
		if (cooldown<0){
			units += model.development;
			if (units > model.capability)
				units = model.capability;
			if(owner){
				cooldown = Config.haveOwnerSpaceBodyCounterCooldown;
			}else cooldown = Config.noOwnerSpaceBodyCounterCooldown;
		}
	}

}
