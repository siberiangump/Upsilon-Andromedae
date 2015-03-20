using UnityEngine;
using System.Collections;

public class NodeUI : MonoBehaviour {

	public GameObject mg;
	// Use this for initialization
	void Start () {
		mg=GameObject.Find("mainGui")as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = mg.transform.localScale;
	}
}
