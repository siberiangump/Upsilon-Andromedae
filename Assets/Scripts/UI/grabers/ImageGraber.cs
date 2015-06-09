using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Image))]
public abstract class ImageGraber : MonoBehaviour {
	
	public GameObject gmo;
	public Image image;
	
	// Use this for initialization
	void Start () {
		image = this.GetComponent<Image>();
		CorrectTarget ();
	}
	
	public void Init(GameObject g){
		gmo=g;
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
		if (image == null) {
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
