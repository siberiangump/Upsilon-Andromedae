using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditorSave : MonoBehaviour {

	public EditorMain main=null;
	public dbEntry dbProxy;
	public Text save_name;

	void Start(){
		main = GameObject.FindGameObjectWithTag ("GameController").GetComponent<EditorMain> ();
	}

	public void Save(){
		if (!main) return;



		if (save_name.text != "") {
			dbProxy.create (new savestract (save_name.text, "{" +
			                                "\"name\":\""+save_name.text+"\"," +
			                                "\"update\":\""+System.DateTime.Now+"\"," +
			                                "\"body\":\""+MapJSONInterface.GetSaveString()+"\"," +
			                                "}"));
		}
	}
}
