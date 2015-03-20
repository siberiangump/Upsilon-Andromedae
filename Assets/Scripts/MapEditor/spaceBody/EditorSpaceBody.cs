using UnityEngine;
using System.Collections;

public class EditorSpaceBody : MonoBehaviour {

	public GameObject nameText;

	public int P;
	private bool showMenu; 
	public bool isMoving=false;
	public GameObject lineHolder;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseUp() {
		if (isMoving)
						isMoving = false;
		else this.BroadcastMessage("ChangeVisibiltyState");
	}

	/// <summary>
	/// menu items	/// </summary>

	public void CreateConnection(){
		string nm = "Q" + GameObject.FindGameObjectsWithTag (lineHolder.tag).Length;
		GameObject line =  Instantiate (lineHolder)as GameObject;
		line.name = nm;
		line.GetComponent<DrawLineToTarget>().destination= this.gameObject;
		this.BroadcastMessage("HideMenu");
	}

	public GameObject CreateConnection(string name){
		GameObject line =  Instantiate (lineHolder)as GameObject;
		line.name = name;
		line.GetComponent<DrawLineToTarget>().destination= this.gameObject;
		this.BroadcastMessage("HideMenu");
		return line;
	}

	public void Remove(){
		GameObject[] t = GameObject.FindGameObjectsWithTag("transition");
		foreach(GameObject gmo in t){
			if(gmo.GetComponent<LineHolder>().from==this.gameObject||gmo.GetComponent<LineHolder>().target==this.gameObject)
			Destroy(gmo.gameObject);
		}
		Destroy (this.gameObject);
	}

	public void ActiveEditMode(){
//		GameObject.Find ("shield").GetComponent<shieldTextInputSystem>().OnNodeEditMenu (this.gameObject);
	}

	public void ActiveMoveMode(){
		isMoving=true;	
	}

	// Update is called once per frame
	void Update () {
		if (nameText)
			nameText.GetComponent<TextMesh> ().text = this.name;

		if(isMoving){
			Vector2 mousePos = Input.mousePosition; 
			Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 10.0f)); 
			transform.position = wantedPos; 
		}
	}
}