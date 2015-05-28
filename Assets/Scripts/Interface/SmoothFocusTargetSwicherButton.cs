using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothFocusTargetSwicherButton : MonoBehaviour {

	public Button button;
	SmoothFocus targetCamera; 
	Transform target;

	// Use this for initialization
	void Start () {
		if(!ButtonComponentValidation()){
			Destroy(this);
		}
	}

	void SetFocusToMe(){
		targetCamera.SetFocus(target);
	}

	public void Init(GameObject gmo){
		if(CameraFocusComponentValidation()){
			target = gmo.transform;
			if(ButtonComponentValidation()){
				button.onClick.AddListener(SetFocusToMe);
			}
		}
	}

	bool ButtonComponentValidation(){
		if(button==null){
			button = this.GetComponent<Button>();
			if(button==null){
				return false;
			}
		}
		return true;
	}

	bool CameraFocusComponentValidation(){
		if(targetCamera==null){
			targetCamera = FindObjectOfType<SmoothFocus>();
			if(targetCamera==null){
				return false;
			}
		}
		return true;
	}
	

}
