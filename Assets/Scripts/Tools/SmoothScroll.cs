using UnityEngine;
using System.Collections;

public class SmoothScroll : MonoBehaviour {

	public float smooth;
	public float[] distances; 
	public int current_distance;
	int cd,maxcd=30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (cd == 0) {
			if (Input.GetAxis ("Mouse ScrollWheel") < 0 && current_distance < distances.Length-1)
				MoveTo (+1);
			if (Input.GetAxis ("Mouse ScrollWheel") > 0 && current_distance > 0 )
				MoveTo (-1);
		}if (cd > 0)
						cd--;
		this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x,this.transform.position.y,-distances[current_distance]),Time.deltaTime * smooth); 
	}

	void MoveTo(int to){
		current_distance+=to;
		cd = maxcd;
	}

	public void ZoomIn(){
		if (current_distance > 0) {
			MoveTo (-1);
		}
	}

	public void ZoomOut(){
		if (current_distance < distances.Length - 1) {
			MoveTo (+1);
		}
	}
}
