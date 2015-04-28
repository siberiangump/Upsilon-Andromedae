using UnityEngine;
using System.Collections;

public class MouseHolder : MonoBehaviour {
	public bool keepZ;
	public Vector3 startMoveVector;
	public float swape;
	public Vector3 moveVector,p;
	public GameObject target; 
	public Vector2 mp;
	public Camera other;
	
	public bool double_click=true; 

	public bool block=true;

	void Update () {
		if(!block){Move();}
	}

	public void Move(){
		Vector3 mousePos;
		mousePos = Input.mousePosition;
		if (target != null) {
			if(keepZ)p = this.GetComponent<Camera>().ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y,target.transform.position.z-this.transform.position.z));
			else p = this.GetComponent<Camera>().ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 10));
			target.transform.position = p;
			if (Input.GetMouseButtonUp (0)){
				if(double_click){
					target.BroadcastMessage("goToDefaultLayer",SendMessageOptions.DontRequireReceiver);
					target = null;
					//keepZ=false;
				}else double_click=true;
			}
			
		}else if (Input.GetMouseButton (0)) {
			p = this.GetComponent<Camera>().ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y,this.transform.position.z*-1));
			moveVector = new Vector3(startMoveVector.x-p.x,startMoveVector.y-p.y,0);
			this.transform.position+=moveVector;
			p = this.GetComponent<Camera>().ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y,this.transform.position.z*-1));
			startMoveVector = p;
		}
		p = this.GetComponent<Camera>().ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y,this.transform.position.z*-1));
		startMoveVector = p;
		//mousePos = Input.mousePosition;
		//p = camera.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 10));
	}

	public void GoToZero(){
		this.transform.position = new Vector3 (0, 0, this.transform.position.z);
	}

	public void Block(){
		block=true;
	}

	public void UnBlock(){
		block=false;
	}
}
