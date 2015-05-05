using UnityEngine;
using System.Collections;

public class Capability : TextGraber {

	SpaceBodyModel model;

	public override void Grab (){
		if (model == null) {
			model = gmo.GetComponent<SpaceBodyModel>();
		}
		if (model) {
			text.text = model.capability.ToString ();
		}
	}
}
