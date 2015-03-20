using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeepZScript : MonoBehaviour {

	public MouseHolder mouseholder;
	public Image ui;
	public Color on, off;

	public void Start(){
		if(mouseholder==null)return;
		if(mouseholder.keepZ)ui.color = on;
		else ui.color = off;
	}

	public void switchState(){
		if(mouseholder==null)return;
		mouseholder.keepZ = !mouseholder.keepZ;
		if(mouseholder.keepZ)ui.color = on;
		else ui.color = off;
	}
}
