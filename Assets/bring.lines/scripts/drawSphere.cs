using UnityEngine;
using System.Collections;

public class drawSphere : MonoBehaviour {

	public float r;
	public Color c;
	public Material material;

	float old_r;
	Color old_c;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material = material;
		this.gameObject.transform.localScale= new Vector3(1, 1, 0);
	}

	void Draw () {
		
		old_r = r;
		old_c = c;
		
		
		this.gameObject.transform.localScale= new Vector3(r * 2, 2 * r, 0);
		this.material.color = c;
	}

	public void ChangeRadius(float radius){
		r = radius;
	}

	// Update is called once per frame
	void Update () {
		if (old_r != r || old_c != c)
			Draw ();
	}
}
