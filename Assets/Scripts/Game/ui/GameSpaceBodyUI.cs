using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameSpaceBodyUI : MonoBehaviour {

	MouseHolder mh;
	bool lockMove=false;
	public Text uiname;
	public Text development;
	public Text capability;

	GameObject spaceBody;
	GameSpaceBody gameSpaceBody;
	
	//public GameObject panel;
	
	void Start(){
		Draw();
		if (!this.transform.parent) {
			DestroyImmediate (this.gameObject);		
		} else {


		}
	}

	void Draw(){
		spaceBody = this.transform.parent.gameObject;
		gameSpaceBody = spaceBody.GetComponent<GameSpaceBody>();
		if (uiname){
			uiname.text = spaceBody.name;
		}
		if (development){
			development.text = "+" +  spaceBody.GetComponent<SpaceBodyModel>().development.ToString();
		}
		if (capability){
			capability.text = spaceBody.GetComponent<SpaceBodyModel>().capability.ToString();
		}
	}

	public void Selected(){
		if(spaceBody==null){ 
			return;
		}
		if(gameSpaceBody.status == GameSpaceBody.Status.selected){
			EventManager.Instance.Emit(EventDefine.space_body_unselected,spaceBody);
		}else if(gameSpaceBody.status == GameSpaceBody.Status.target){
			EventManager.Instance.Emit(EventDefine.space_body_selected_as_target,spaceBody);
		}else if(gameSpaceBody.status == GameSpaceBody.Status.active){
			EventManager.Instance.Emit(EventDefine.space_body_selected,spaceBody);
		}

	}
}
