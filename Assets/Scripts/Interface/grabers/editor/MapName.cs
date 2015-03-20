using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapName : TextGraber {
	public override void Grab ()
	{
		if (gmo.GetComponent<EditorMain> ()) {
			text.text = gmo.GetComponent<EditorMain> ().mapName;
		}
	}
}
