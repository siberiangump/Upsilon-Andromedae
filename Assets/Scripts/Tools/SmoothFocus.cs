using UnityEngine;
using System.Collections;

public class SmoothFocus : MonoBehaviour {

	public Transform defaultFocus;
 	public Transform target;
	public float smooth;
		
	void Start() {
		target = defaultFocus;
	}

	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(target.position.x,target.position.y,this.transform.position.z),Time.deltaTime * smooth); 
	}

	public void SetFocus(Transform to){
		target = to;
	}
	
	public void CleanFocus(Transform from){
		if (target == from) {
			target = defaultFocus;
		}
	}
}
