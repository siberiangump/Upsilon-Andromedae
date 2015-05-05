using UnityEngine;
using System.Collections;

public class Development : TextGraber {

	SpaceBodyModel model;
	
	public override void Grab (){
		if (model == null) {
			model = gmo.GetComponent<SpaceBodyModel>();
		}
		if (model) {
			text.text = model.development.ToString ();
		}
	}
}
