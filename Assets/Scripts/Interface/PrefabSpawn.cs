using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrefabSpawn : ObjectPreview {

	public GameObject prefab;

	public Component[] SpawnComponents;
	public GameObject[] SpawnChilds;

	MouseHolder mh;

	// Use this for initialization
	void Start () {
		mh = GameObject.Find ("Main Camera").GetComponent<MouseHolder>();
		this.gameObject.tag = "prefab";
	}

	public void Init(){
		this.GetComponent<Image> ().sprite = this.image;
	}

	public void InstantietePrefab() {
		GameObject gmo = Instantiate (prefab)as GameObject;
		gmo.name = NameGenerator.gen_name ();

		mh.target = gmo;

		gmo.GetComponent<ObjectPreview> ().prefab_name = this.prefab.name;
		gmo.transform.position = new Vector3 (0,0,-20);
		foreach (GameObject c in SpawnChilds) {
			GameObject g = Instantiate (c,gmo.transform.position,Quaternion.identity)as GameObject;
			g.transform.parent = gmo.transform;
			g.GetComponent<RectTransform>().Rotate(0,180,0);
		}
	}
}

