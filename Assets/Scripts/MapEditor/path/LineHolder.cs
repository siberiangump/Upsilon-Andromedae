using UnityEngine;
using System.Collections;

public class LineHolder : MonoBehaviour {

	public GameObject from, target;
	public int distance;

	// Use this for initialization
	void Start () {
		from = this.GetComponent<DrawLineToTarget> ().destination;
	}

	public void FixTarget(GameObject gmo){
		target = gmo;
		this.GetComponent<Collider>().enabled = false;
	}

	void OnTriggerStay(Collider other) {
		if(Input.GetMouseButton(0)){
			target=other.gameObject;
			this.GetComponent<Collider>().enabled = false;
		}
		Debug.Log (other.gameObject.name + "t");
	}
	
	// Update is called once per frame
	void Update () {

		if (this.GetComponent<Collider>().enabled && Input.GetMouseButtonUp (1))
				Destroy (this.gameObject);

		if (target==null) {
				Vector2 mousePos = Input.mousePosition; 
		   		Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 10.0f)); 
		 		transform.position = wantedPos;
		} else 
				this.transform.position = target.transform.position;

	}
}
