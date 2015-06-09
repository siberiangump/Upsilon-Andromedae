using UnityEngine;
using System.Collections;

public class SaveFinder : MonoBehaviour {

/*	public dbEntry dbProxy;
	public GameObject prefab;
	public int displacement;
	public GameObject[] gmos;
	
	void Start() {

		Vector2 t = this.GetComponent<RectTransform> ().sizeDelta;
//		string[] ids = dbProxy.getIdList ();
		this.GetComponent<RectTransform> ().sizeDelta=new Vector2(t.x,(ids.Length) * displacement);
		t = this.GetComponent<RectTransform> ().sizeDelta;
		for(int i=0;i<ids.Length;i++) {
			GameObject g = Instantiate(prefab)as GameObject;
			g.transform.parent = this.transform;
			g.GetComponent<RectTransform>().localPosition = new Vector3(0,i*displacement+displacement/2-t.y/2,0);
			savestract ps = dbProxy.get (ids[i]);
			SavePreview op = g.GetComponent<SavePreview>();
			if(op){
				op.name=ps.n;
				op.date=ps.time;
				op.id=ps.id;
				op.Init();
			}
		}
		
	} */

}
