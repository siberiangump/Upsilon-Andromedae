using UnityEngine;
using System.Collections;

public class UITarget : MonoBehaviour {

	public UITargetType type;
	public GameObject target;
	
	// Use this for initialization
	void Start () {
		if (type == UITargetType.caster) {
			this.BroadcastMessage("SetTarget",target);		
		}
	}

	public void SetTarget(GameObject t){
		target = t;
	}

	public void SayToTarget(string method){
		target.BroadcastMessage (method);
	}
}

public enum UITargetType {caster,listener} 
