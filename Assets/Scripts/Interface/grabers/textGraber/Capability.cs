using UnityEngine;
using System.Collections;

public class Capability : TextGraber {

	SpaceBodyModel model;

	public override void Grab (){
		if (model) {
			text.text = model.capability.ToString ();
		}
	}

	public override void SubscribingOnChanges(){
		if (model == null) {
			model = gmo.GetComponent<SpaceBodyModel>();
			model.Subscribe(UpdateText);
		}
	}
}
