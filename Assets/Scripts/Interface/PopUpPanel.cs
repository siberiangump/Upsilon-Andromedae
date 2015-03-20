using UnityEngine;
using System.Collections;

public class PopUpPanel : MonoBehaviour {

	public string text;
	public GameObject target;
	public string method;
	public string parametr="";

	public void Yes(){
		if (target) {
			if (parametr == "") {
				target.BroadcastMessage (method);
			} else	target.BroadcastMessage (method, parametr);
		}
	}
	
	public void No(){
		Destroy (this.gameObject);
	}
}
