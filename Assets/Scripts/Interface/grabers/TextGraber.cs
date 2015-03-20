using UnityEngine;
using UnityEngine.UI;

public abstract class TextGraber : MonoBehaviour {

	public GameObject gmo;
	public Text text;

	// Use this for initialization
	void Start () {
		CorrectTarget ();
		if (gmo == null) {
			DestroyImmediate(this.gameObject);		
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!Validation ()){
			return;		
		}
		Grab ();
	}

	public abstract void Grab ();

	public virtual void CorrectTarget (){
		if (gmo == null) {
			gmo = GameObject.FindGameObjectWithTag ("GameController");
		}
	}

	bool Validation(){
		if (text == null) {
			Debug.Log("no UI text");
			return false;
		}
		if (gmo == null) {
			Debug.Log("no gmo grab from");
			return false;
		}
		return true;
	}

}
