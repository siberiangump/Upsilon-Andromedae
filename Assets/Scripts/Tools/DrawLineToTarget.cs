using UnityEngine;
using System.Collections;

public class DrawLineToTarget : MonoBehaviour {

	private LineRenderer lineRndrer;
	public GameObject destination;
	public float displacement;
	private float distence;


	// Use this for initialization
	void Start () {

		lineRndrer = GetComponent<LineRenderer> ();
		lineRndrer.SetPosition (0, this.transform.position);
		lineRndrer.SetColors (Color.white, Color.gray);
	}
	
	// Update is called once per frame
	void Update () {
		lineRndrer.SetWidth (0.06f, 0.06f);

		lineRndrer.SetPosition (0,new Vector3(this.transform.position.x,this.transform.position.y+displacement));
		if(destination!=null)  lineRndrer.SetPosition (1, destination.transform.position);
	}
}
