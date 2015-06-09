using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent (typeof(Motor))]
public class GameUnit : MonoBehaviour {

	public Motor motor;
	public SpriteRenderer color;

	// Use this for initialization
	void Awake () {
		if(motor==null){
			motor = this.GetComponent<Motor>();
		}
	}

	public void Init (GameObject target, Color color, UnityAction onTargetReached) {
		if(!Validation()){
			return;
		}
		motor.OnTargetReached = onTargetReached;
		motor.GoTo(target);
		this.color.color = new Color (color.r,color.g,color.b,.80f);
	}

	bool Validation(){
		motor = this.GetComponent<Motor>();
		if(motor==null){
			return false;
		}
		if(color==null){
			return false;
		}
		return true;
	} 

	// Update is called once per frame
	void Update () {
	
	}
}
