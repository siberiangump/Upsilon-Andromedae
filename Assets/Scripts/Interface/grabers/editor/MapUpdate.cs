using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapUpdate : TextGraber {
	public override void Grab ()
	{
		if (gmo.GetComponent<EditorMain> ()) {
			text.text = gmo.GetComponent<EditorMain> ().mapUpdate;
		}
	}
}
