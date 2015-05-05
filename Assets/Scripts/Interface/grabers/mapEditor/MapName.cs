using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapName : TextGraber {

	public override void Grab ()
	{
		if (gmo.GetComponent<MapModel> ()) {
			text.text = gmo.GetComponent<MapModel> ().name.ToUpper();
		}
	}

}
