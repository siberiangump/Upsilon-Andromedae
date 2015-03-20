using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditorSpaceBodyUI : MonoBehaviour {

	MouseHolder mh;
	bool lockMove=false;
	public GameObject linePrefab;
	public Text uiname;
	public GameObject panel;

	void Start(){
		if (!this.transform.parent) {
			DestroyImmediate (this.gameObject);		
		} else {
			this.transform.parent.gameObject.name = gen_name ();
			if (uiname)
				uiname.text = this.transform.parent.gameObject.name;
		}
	} 

	public void LockMove(){
		lockMove=!lockMove;
	}

	public void Highlight(){
		PlayerPrefs.SetString("SelectedBody",this.transform.parent.name);
	}

	public void Clicked(){
		panel.SetActive (!panel.activeSelf);
	}

	public void Move(){
		if (lockMove)return;

		if (mh) {
			mh.target = this.transform.parent.gameObject;
		
		} else {
			mh=FindMouseHolder ();
			if(mh){
				mh.target = this.transform.parent.gameObject;
			
			}
		}
	}

	public void Remove(){
		GameObject.Destroy (this.transform.parent.gameObject);
	}

	public void Connect(){
		GameObject gmo = Instantiate (linePrefab)as GameObject;
		gmo.BroadcastMessage ("Init", new LineParametrData (this.transform.parent, gmo.transform));
		if (mh) {
			mh.target = gmo;
			mh.double_click = false;
		} else {
			mh=FindMouseHolder ();
			if(mh){
				mh.target = gmo;
				mh.double_click = false;
			}
		}
		panel.SetActive (false);
		gmo.AddComponent<ChangeLineTarget> ();
	}

	public MouseHolder FindMouseHolder(){
		return GameObject.Find ("Main Camera").GetComponent<MouseHolder>();
	}


	public string gen_name(){
		string[] characters1 = new string[] {"b", "c", "d", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z"};
		string[] characters2 = new string[] {"a", "e", "o", "u"};
		string[] characters3 = new string[] {"br", "cr", "dr", "fr", "gr", "pr", "str", "tr", "bl", "cl", "fl", "gl", "pl", "sl", "sc", "sk", "sm", "sn", "sp", "st", "sw", "ch", "sh", "th", "wh"};
		string[] characters4 = new string[] {"ae", "ai", "ao", "au", "a", "ay", "ea", "ei", "eo", "eu", "e", "ey", "ua", "ue", "ui", "uo", "u", "uy", "ia", "ie", "iu", "io", "iy", "oa", "oe", "ou", "oi", "o", "oy"};
		string[] characters5 = new string[] {"turn", "ter", "nus", "rus", "tania", "hiri", "hines", "gawa", "nides", "carro", "rilia", "stea", "lia", "lea", "ria", "nov", "phus", "mia", "nerth", "wei", "ruta", "tov", "zuno", "vis", "lara", "nia", "liv", "tera", "gantu", "yama", "tune", "ter", "nus", "cury", "bos", "pra", "thea", "nope", "tis", "clite"};		
		
		
		int Random1 = Random.Range(0,characters1.Length);
		int Random2 = Random.Range(0,characters2.Length);
		int Random3 = Random.Range(0,characters3.Length);
		int Random4 = Random.Range(0,characters4.Length);	
		int Random5 = Random.Range(0,characters5.Length);
		
		
		string name = characters1[Random1] + characters2[Random2] + characters5[Random5];
		
		return name;
	}

}
