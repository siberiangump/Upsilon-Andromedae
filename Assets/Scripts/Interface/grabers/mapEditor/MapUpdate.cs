using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapUpdate : TextGraber {

	public override void Grab ()
	{
		if (gmo.GetComponent<MapModel> ()) {
			text.text = gmo.GetComponent<MapModel> ().lastSave;
		}
	}
}
