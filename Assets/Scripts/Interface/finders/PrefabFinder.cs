using UnityEngine;
using System.Collections;

public class PrefabFinder : MonoBehaviour {

	public GameObject prefab;
	public int displacement;
	public string path;
	public GameObject[] gmos;

	void Start() {

		gmos = Resources.LoadAll<GameObject> (path) as GameObject[];
		Vector2 t = this.GetComponent<RectTransform> ().sizeDelta;
		this.GetComponent<RectTransform> ().sizeDelta=new Vector2((gmos.Length) * displacement,t.y);
		t = this.GetComponent<RectTransform> ().sizeDelta;
		for(int i=0;i<gmos.Length;i++) {
			GameObject g = Instantiate(prefab)as GameObject;
			g.transform.parent = this.transform;
			g.GetComponent<RectTransform>().localPosition = new Vector3(i*displacement+displacement/2-t.x/2,0,0);
			PrefabSpawn ps = g.GetComponent<PrefabSpawn>();
			ps.prefab = gmos[i];
			ObjectPreview op = gmos[i].GetComponent<ObjectPreview>();
			if(op){
				ps.image = op.image;
				ps.Init();
			}
		}

	} 

	// Update is called once per frame
	void Update () {
		//Instantiate
	}
}
