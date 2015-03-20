using UnityEngine;
using System.Collections;

public class GameSpaceBody : SpaceBodyModel {

	public int units = 0; 
	public GameObject UI;
	// Use this for initialization
	void Awake () {

		ObjectPreview op = this.GetComponent<ObjectPreview> ();
		this.capability = op.capability;
		this.development = op.development;
		Destroy (op);
		GameObject ui = Instantiate (UI, this.transform.position, Quaternion.identity) as GameObject;
		ui.transform.parent = this.transform;
		ui.transform.Rotate (new Vector3 (0, 180, 0));
		StartCoroutine(RunGainer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator RunGainer () {
		while (true) {
			yield return new WaitForSeconds (1);
			Debug.Log ("asd");
			units += development;
			if (units > capability)
				units = capability;
		}
	}

}
