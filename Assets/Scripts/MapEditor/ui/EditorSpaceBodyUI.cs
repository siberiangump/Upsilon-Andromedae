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




}
