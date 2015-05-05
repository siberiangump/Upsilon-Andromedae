using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameSpaceBodyUI : MonoBehaviour {

	MouseHolder mh;
	bool lockMove=false;
	public Text uiname;
	public Text development;
	public Text capability;


	//public GameObject panel;
	
	void Start(){
		if (!this.transform.parent) {
			DestroyImmediate (this.gameObject);		
		} else {
			if (uiname){
				uiname.text = this.transform.parent.gameObject.name;
			}
			if (development){
				development.text = "+" +  this.transform.parent.GetComponent<SpaceBodyModel>().development.ToString();
			}
			if (capability){
				capability.text = this.transform.parent.GetComponent<SpaceBodyModel>().capability.ToString();
			}

		}
	} 
	
	public void Clicked(){
	//	panel.SetActive (!panel.activeSelf);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
