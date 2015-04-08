using UnityEngine;
using System.Collections;

public class GameSpaceBody : SpaceBodyModel {

	public int units = 0; 
	public GameObject UI;
	public PlayerModel owner = null; 
	public float cooldown ;

	float cdNoOwner = 2;
	float cdHaveOwner= 1;

	// Use this for initialization
	void Awake () {

		ObjectPreview op = this.GetComponent<ObjectPreview> ();
		this.capability = op.capability;
		this.development = op.development;
		Destroy (op);
		GameObject ui = Instantiate (UI, this.transform.position, Quaternion.identity) as GameObject;
		ui.transform.parent = this.transform;
		ui.transform.Rotate (new Vector3 (0, 180, 0));
		if(owner){
			cooldown = cdHaveOwner;
		}else cooldown = cdNoOwner;
	}

	// Update is called once per frame
	void Update () {
		Gainer ();
	}
	

	void Gainer () {
		cooldown -= Time.deltaTime;
		if (cooldown<0){
			units += development;
			if (units > capability)
				units = capability;
			if(owner){
				cooldown = cdHaveOwner;
			}else cooldown = cdNoOwner;
		}
	}

}
