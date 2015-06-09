using UnityEngine;
using UnityEngine.UI;

public abstract class TextGraber : MonoBehaviour {

	public GameObject gmo;
	public Text text;

	// Use this for initialization
	void Start () {
		CorrectTarget ();
		SubscribingOnChanges();
	}

	public void Init(GameObject g){
		gmo=g;
		SubscribingOnChanges();
	}

	public void UpdateText () {
		if (!Validation ()){
			return;		
		}
		Grab ();
	}

	public abstract void Grab ();

	public abstract void SubscribingOnChanges();

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
