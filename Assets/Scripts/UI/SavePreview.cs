using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SavePreview : MonoBehaviour {

	public Sprite image;
	public string savePreviewName;
	public string date;
	[HideInInspector]
	public string id;
	public string description;


	public Text nameUI;
	public Text dateUI;
	public Text descriptionUI;

	public void Init(){
		nameUI.text = name;
		dateUI.text = date;
//		descriptionUI.text = description;
	}
}
