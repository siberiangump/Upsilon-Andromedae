using UnityEngine;
using System.Collections;

public class ChangeLineTarget : MonoBehaviour {

	bool double_click=false;
	void Update(){
		if (Input.GetMouseButtonUp (0)) {
			if(double_click){
				GameObject gmo = GameObject.Find (PlayerPrefs.GetString ("SelectedBody")) as GameObject;
				if (gmo) {
					this.GetComponent<drawLine> ().to = gmo.transform;
					GameObject.Destroy (this);
				} else
					GameObject.Destroy (this.gameObject);
				if(this.GetComponent<drawLine> ().from==gmo.transform)GameObject.Destroy (this.gameObject);
			} else double_click=true;
		}
	}
}
