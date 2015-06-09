using UnityEngine;
using System.Collections;

public class Development : TextGraber {

	SpaceBodyModel model;
	
	public override void Grab (){
		if (model) {
			text.text = "+" + model.development.ToString ();
		}
	}
	
	public override void SubscribingOnChanges(){
		if (model == null) {
			model = gmo.GetComponent<SpaceBodyModel>();
			model.Subscribe(UpdateText);
		}
	}
}
