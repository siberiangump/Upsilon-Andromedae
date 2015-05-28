using UnityEngine;
using System.Collections;

public class SmoothFocus : MonoBehaviour {

	public float smooth=.5f;
	public Transform target;
	public OnAction onMouseAction=OnAction.Ignor;
	public OnAction onTargetReach=OnAction.Ignor;
	public float distance=.5f;

	public Transform defaultFocus;

		
	//public bool run=true;

	void Start() {
		target = defaultFocus;
	}

	// Update is called once per frame
	void Update () {
		if(onMouseAction==OnAction.Stop){
			if(Input.GetMouseButtonDown(0)){
				target = null;
			}
		}
		if(onTargetReach==OnAction.Stop){
			if(target!=null){
				Vector2 a= new Vector2 (transform.position.x,transform.position.y);
				Vector2 b= new Vector2 (target.position.x,target.position.y);
				if(Vector2.Distance(a,b)<distance){
					target = null;
				}
			}
		}

		Move();

	}

	void Move(){
		if(target!=null){
			this.transform.position = Vector3.Lerp( this.transform.position,
			                                   		new Vector3( target.position.x,
			            									     target.position.y,
			            										 this.transform.position.z),
			                                   		Time.deltaTime * smooth); 
		}
	}

	public void SetFocus(Transform to){
		target = to;
	}
	
	public void CleanFocus(Transform from){
		if (target == from) {
			target = defaultFocus;
		}
	}

	public enum OnAction {Stop,Ignor};
}
