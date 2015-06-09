using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Motor : MonoBehaviour {
	
	public ZPosition z=ZPosition.static_z;
	public float speed = 10.0F;
	public float dex = 2;
	public GameObject childSprite;
	GameObject pointer;
	public GameObject target=null;
	public UnityAction OnTargetReached;


	// Use this for initialization
	void Start () {
//		target = null;
	}
	
	public void init(float speed,float dex,int mass){
		speed = speed;
		dex = dex;
	} 
	
	void Update() {
		if(target!=null){
			moveViaTarget();
		}
	}

	public void GoTo(GameObject target){
		this.target = target;
	}

	//	public void goTo(string gmoName){
	//		pointer = this.GetComponent<mouse_move_cursor> ().target;
	//		pointer.GetComponent<LineRenderer> ().enabled = true;
	//		pointer.GetComponent<DrawLineToTarget> ().enabled = true;
	//		goToTarget = GameObject.Find (gmoName);
	//		pointer.transform.position = goToTarget.transform.position;
	
	//	}
	
	//private void moveViaController(){
	//	float y = Input.GetAxis ("Vertical") * speed;
	//	float x = Input.GetAxis ("Horizontal") * speed;
	//	
	//	if (x != 0 || y != 0) {
	//		float rot_z = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;
	//		transform.Rotate(new Vector3(0,0,rot_z - 90) * Time.deltaTime);
	//		
	//		y *= Time.deltaTime;
	//		x *= Time.deltaTime;
	//		transform.Translate (x, y, transform.position.z);
	//	}
	//}
	
	private void moveViaTarget(){
		//pointer.transform.position = goToTarget.transform.position;
		float y1 = target.transform.position.y-this.transform.position.y;
		float x1 = target.transform.position.x-this.transform.position.x;
		
		transform.Translate (new Vector3(1,0,0).normalized  * Time.deltaTime * speed);
		if(z == ZPosition.non_static_z){
			Vector3 zVector = new Vector3(0,0,(target.transform.position.z - this.transform.position.z) * Time.deltaTime * speed);
			this.transform.position += zVector;
		}


		float rot_z = Mathf.Atan2 (y1, x1) * Mathf.Rad2Deg;
		if (rot_z < 0) rot_z = 360 + rot_z;
		float this_z = this.transform.rotation.eulerAngles.z;
		
		if (this_z - rot_z > 10 && this_z - rot_z < 180 || rot_z - this_z > 180 && rot_z - this_z < 350) {
			transform.Rotate (new Vector3 (0, 0, -90) * Time.deltaTime * dex, Space.World);
		} else if (rot_z - this_z > 10 && rot_z - this_z < 180 || this_z - rot_z > 180 && this_z - rot_z < 350) {
			transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime * dex, Space.World);
		}
		if(Vector3.Distance(this.transform.position,target.transform.position)<0.5f){
			if( OnTargetReached != null){
				OnTargetReached();
				Destroy(this.gameObject);
				return;
			}
			target=null;
		}
	}

	public enum ZPosition {static_z, non_static_z};
}
