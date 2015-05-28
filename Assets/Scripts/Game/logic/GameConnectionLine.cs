using UnityEngine;
using System.Collections;

[RequireComponent (typeof (DrawLine))]
public class GameConnectionLine : MonoBehaviour {

	public DrawLine drawer; 

	// Use this for initialization
	void Start () {
		if(!Validation()){
			return;
		}
		EventsSubscriptions();
	}

	void EventsSubscriptions(){
		EventManager.Instance.Subscribe(EventDefine.space_body_selected,OnSpaceBodySelected);
		EventManager.Instance.Subscribe(EventDefine.space_body_unselected,OnSpaceBodyUnselected);
		EventManager.Instance.Subscribe(EventDefine.space_body_selected_as_target,OnSpaceBodyUnselected);
	}

	bool Validation(){
		if(drawer==null){
			drawer = this.GetComponent<DrawLine>();
		}
		if(drawer==null){
			return false;
		}
		return true;
	}

	void OnSpaceBodyUnselected(GameObject spaceBody){
		drawer.fromColor = Config.Instance.nonactive;
		drawer.toColor = Config.Instance.nonactive;
	}
	
	void OnSpaceBodySelected(GameObject spaceBody){
		SpaceBodyModel from = drawer.from.gameObject.GetComponent<SpaceBodyModel>();
		SpaceBodyModel to = drawer.to.gameObject.GetComponent<SpaceBodyModel>();
		if(from.gameObject.GetInstanceID() != spaceBody.GetInstanceID() && to.gameObject.GetInstanceID() != spaceBody.GetInstanceID()){
			drawer.fromColor = Config.Instance.nonactive;
			drawer.toColor = Config.Instance.nonactive;
			return;
		}
		if(from.playerId != to.playerId){
			drawer.fromColor = Config.Instance.attack;
			drawer.toColor = Config.Instance.attack;
		}else{
			drawer.fromColor = Config.Instance.regroup;
			drawer.toColor = Config.Instance.regroup;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
